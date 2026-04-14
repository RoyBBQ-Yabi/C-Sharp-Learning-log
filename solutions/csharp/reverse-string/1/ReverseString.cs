public static class ReverseString
{
    public static string Reverse(string input)
    {
        return string.Join("", input.Reverse());
        
        // 原理：string.Join( 間隔字串 , 目標字串 )：將目標字串分成多個字元並用 "間隔字串進行串接" => (-,ABC) => A-B-C
        // 由於只要反轉字串因此串間的內容為 null
        // input.Reverse()：最後直接使用 Reverse() 進行反轉即可
    }
}