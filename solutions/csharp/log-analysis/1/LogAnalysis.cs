public static class LogAnalysis 
{

    public static string SubstringAfter(this string message, string delimiter) //優先建立兩個字串，原先訊息、搜索訊息，並給予this權限
    {
        return message.Split(delimiter)[1]; //使用split將搜索訊息字串做切分並提取右邊的訊息。
    }
   
    public static string SubstringBetween(this string message , string str1 , string str2)
    {
        return message.Split(str1)[1].Split(str2)[0]; //使用 split 語法切割字串 [0] 代表切割提取左邊，[1] 代表切割提取右邊
    }

    public static string Message(this string message )
    {
        return message.SubstringAfter(": "); //使用 this 抓取先前的方法，抓取後給予指定字串並執行先前方法抓取訊息
    }

    public static string LogLevel(this string message )
    {
        return message.SubstringBetween("[", "]"); //使用 this 抓取先前的方法，抓取後給予指定字串並抓取指定訊息
    }
}