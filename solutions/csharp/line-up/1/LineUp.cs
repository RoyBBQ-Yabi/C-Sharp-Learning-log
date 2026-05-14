public static class LineUp
{
    public static string Format(string name, int number)
    {
        string suffix; 
        int LastTwoDigit = number % 100; // 抓取後兩位數字檢查是否為例外數字(11、12、13結尾)
        int LastDigit = number % 10; // 抓取最後數字
        
        if( LastTwoDigit >= 11 && LastTwoDigit <= 13 ) 
        {
            suffix = "th"; // 如果後兩位是 (11、12、13) 敘數詞為 th
        }else if ( LastDigit == 1 )
        {
            suffix = "st"; // 如果後一位是 1 敘數詞為 st
        }else if ( LastDigit == 2 )
        {
            suffix = "nd"; // 如果後一位是 2 敘數詞為 nd
        }else if ( LastDigit == 3 )
        {
            suffix = "rd"; // 如果後一位是 3 敘數詞為 rd
        }else
        {
            suffix = "th"; // 如果後一位是 其他 敘數詞為 th
        }

        // 回傳預約訊息
        return $"{name}, you are the {number}{suffix} customer we serve today. Thank you!";
    }
}
