using System;
using System.Runtime.InteropServices; 
using System.Globalization;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime(); // 將輸入進來的 UTC 或 未指定時區的時間 轉換成 當下電腦的本地時間
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        // 先偵測裝置在抓取正確的時區 ID
        DateTime localTime = DateTime.Parse(appointmentDateDescription); // 先確認輸入的字串
        
        // 使用 RuntimeInformation 偵測作業系統並取得對應的時區 ID
        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows); 
        string timeZoneId = "";

        switch (location)
        {
            case Location.NewYork: // 確認裝置作業系統，如果是 Window 就給予左邊紐約時區 ID，不是就右邊
                timeZoneId = isWindows ? "Eastern Standard Time" : "America/New_York"; // 紐約 - 美國東部標準時間
                break;
            case Location.London:
                timeZoneId = isWindows ? "GMT Standard Time" : "Europe/London"; // 倫敦 - 格林威治標準時間
                break;
            case Location.Paris:
                timeZoneId = isWindows ? "W. Europe Standard Time" : "Europe/Paris"; // 巴黎 - 西歐標準時間
                break;
        };
        
        // 取得該裝置當下的指定時區，再使用 ConvertTimeToUtc( 當地時間 , 當地時區 ) 將時間轉換 UTC 
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        return TimeZoneInfo.ConvertTimeToUtc(localTime, tz);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        // 提前告知距離預約時間還剩多久，使用 TimeSpan 計算時間間隔
        TimeSpan offSet = alertLevel switch // 三時段作提醒：1D、1H 45M、30M
        {
            AlertLevel.Early    => new TimeSpan(1, 0, 0, 0),    // 1D
            AlertLevel.Standard => new TimeSpan(1, 45, 0),       // 1H 45M
            AlertLevel.Late     => new TimeSpan(0, 30, 0),       // 30M
            _ => throw new ArgumentOutOfRangeException() // 其餘剩餘時間不呼叫
        };
        return appointment - offSet; // 回傳當下時間 (預約時間 - 剩餘時間)
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location) // 夏令時區調整通知，預約時間與前七天 DST 狀態是否相同，相同回傳 true
    {
        // 跟 Schedule 一樣先偵測作業系統，寫法相同
        bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        string timeZoneId = location switch
        {
            Location.NewYork => isWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London  => isWindows ? "GMT Standard Time"     : "Europe/London",
            Location.Paris   => isWindows ? "W. Europe Standard Time" : "Europe/Paris",
            _ => ""
        };
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        // 比較預約時間與前七天 DST 狀態
        bool isCurrentlyDaylight = tz.IsDaylightSavingTime(dt); // 判斷是否夏令，是為 true
        bool wasDaylightSevenDaysAgo = tz.IsDaylightSavingTime(dt.AddDays(-7)); // 判斷前七天狀態

        return isCurrentlyDaylight != wasDaylightSevenDaysAgo; // 確認是否相同，並回傳 bool 值
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        // 依照當地的格式進行預約，若格式錯誤回傳值將以 1/1/1 表示
        // 根據位置設定對應的時間格式
        string cultureName = location switch
        {
            Location.NewYork => "en-US", // 紐約格式
            Location.London  => "en-GB", // 英國格式
            Location.Paris   => "fr-FR", // 法國格式
            _ => ""
        };
        
        // 確認格式是否正確，錯誤回傳 1/1/1
        if (DateTime.TryParse(dtStr, new CultureInfo(cultureName) , DateTimeStyles.None, out DateTime result))
        {
            // 將樹入的字串轉換成當地的日期格式 (DateTime.TryParse)
            // DateTimeStyles.None 不處理特殊字元和時區，使用預設時間格式檢查
            // 使用 out 將 DateTime 轉換的結果，成功的話儲存在 result 中 (使用 TryParse 的 bool 值判斷)
            
            return result; // bool 為 true 回傳時間
        }
            return new DateTime(1, 1, 1); // bool 為 false 格式錯誤回傳 1/1/1
    }
}
