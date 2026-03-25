static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription); // 將輸入的字串解析成 DateTime 的格式。
    }

    public static bool HasPassed(DateTime appointmentDate) // 已轉成 DateTime 模式
    {
        if( appointmentDate < DateTime.Now ) // 使用 DateTime.Now 來抓取電腦現在的時間並判斷預約是否過期
        {
            return true;
        }else
        {
            return false;
        }
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate) // 已轉成 DateTime 模式
    {
       return appointmentDate.Hour >= 12 && appointmentDate.Hour < 18; // 判斷是否在下午，時區為 12~17 點 
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate}."; // 使用 $ 字串方法直接銜接字串與資料並回傳
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime (DateTime.Now.Year, 9, 15, 0, 0, 0); 
        // 建立一個新 DateTime 抓取今年年份並給予新的週年日，應用 DateTime.Now.Year 抓取今年年分
    }
}
