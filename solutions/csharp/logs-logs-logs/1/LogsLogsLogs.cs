// TODO: define the 'LogLevel' enum

// 建立 enum
enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
}
    
static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        // 依照指令將日誌等級代號進行解析
        // 使用 Contains 檢查代號並進行解析回傳
        if (logLine.Contains("[TRC]")) return LogLevel.Trace;
        if (logLine.Contains("[DBG]")) return LogLevel.Debug;
        if (logLine.Contains("[INF]")) return LogLevel.Info;
        if (logLine.Contains("[WRN]")) return LogLevel.Warning;
        if (logLine.Contains("[ERR]")) return LogLevel.Error;
        if (logLine.Contains("[FTL]")) return LogLevel.Fatal;

        return LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        // 將 enum 轉成短格式，等級轉換成對應的數字並給予對應的訊息
        // 使用 (int) 將 enum 格式強轉成整數，並用 $ 做字串連接
        return $"{(int)logLevel}:{message}";
        
    }
}
