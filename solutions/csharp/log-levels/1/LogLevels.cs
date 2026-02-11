static class LogLine
{
    public static string Message(string logLine)
    {
        int colonIndex = logLine.IndexOf(':'); //找出 ":" 的位置
        string message = logLine.Substring(colonIndex + 1); //從 ":" 後一格的位置擷取字串
        
        return message.Trim(); //去除多餘的空白 () 內為要清的字預設為空白
    }

    public static string LogLevel(string logLine)
    {
        int startIndex = logLine.IndexOf('[') + 1; //找出 "[" 的位置並抓取其後面一個的字
        int endIndex = logLine.IndexOf(']'); //找出 "]" 的位置
        int length = endIndex - startIndex; //計算[]內字串的長度
        
        return logLine.Substring(startIndex , length).ToLower(); // 輸出指定的開頭到往後算[]內字串的長度的字並轉換成小寫
    }

    public static string Reformat(string logLine)
    {
        string messageLogLine = Message(logLine); // 抓取先前的訊息結果
        string level = LogLevel(logLine); // 抓取先前已轉換的警訊階級
        
        return $"{messageLogLine} ({level})"; //利用$進行串接，或者使用 a + b + c 來解決
    }
}
