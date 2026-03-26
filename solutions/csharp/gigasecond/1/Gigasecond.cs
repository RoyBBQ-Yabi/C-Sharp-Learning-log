public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        // 定義一吉秒且為 double 值，因為 AddSeconds 接收類別為 double
        // const 表示此為固定的值不會受到更動，可用來定義一個標準
        const double Gigasecond = 1000000000.0;

        return moment.AddSeconds(Gigasecond); // AddSeconds() 會自動換算內容秒數為幾天 or 幾年(包含大小月、閨年等情況)
    }
}