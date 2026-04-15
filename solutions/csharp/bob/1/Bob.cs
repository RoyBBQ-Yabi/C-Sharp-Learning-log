public static class Bob
{
    public static string Response(string statement)
    {
        string trimmed = statement.Trim(); // 將前後空格刪掉以免出現誤判
        char[] arr= trimmed.ToCharArray(); // 將修改後的字串轉為陣列
        
        if(string.IsNullOrEmpty(trimmed)) // 字串裡面沒有內容
        {
            return "Fine. Be that way!";
        }

        bool hasLetter = false; // 是否有包含英文字母
        bool allUpper = true; // 是否全大寫的確認開關
        
        for(int i = 0 ; i < arr.Length ; i++) // 用 for 迴圈看過每個字元並進行比對
        {
            if(char.IsLetter(arr[i])) // 過濾所有非英文字母的字元( 英文數字混雜自動無視數字 )，如果全都沒英文則 hasLetter 為 false
            {
                hasLetter = true;
                if( !char.IsUpper(arr[i]) ) // 如果有一個字元不是大寫將判定改為 false
                {
                    allUpper = false;
                }
            }
        }

        bool isYelling = hasLetter && allUpper; // 若為全大寫則為判定大吼大叫
        bool isQuestion = trimmed.EndsWith("?"); // 若最後的字是 ? 則判定為疑問句

        if (isYelling && isQuestion) // 大吼 + 疑問
        {
            return "Calm down, I know what I'm doing!";
        }
        else if (isYelling) // 大吼大叫
        {
            return "Whoa, chill out!";
        }
        else if (isQuestion) // 單純疑問
        {
            return "Sure.";
        }
        else // 其他全部的對談內容
        {
            return "Whatever.";
        }
    }
}