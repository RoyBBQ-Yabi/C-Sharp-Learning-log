using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        // StringBuilder 就像是一個空籃子，然後將要的字元丟進去或省略掉
        
        StringBuilder sb = new StringBuilder(); // 建立一個 StringBuilder
        bool isAfterKebab = false; // 判斷前一個字元是否為橫線

        foreach (char c in identifier) // 用 foreach 將輸入的字串逐一進行篩檢，比寫 for 簡潔
        {
            if ( c == ' ' ) // 第一題將空格替換成 _ ( 將 ' ' 無視然後將 '_' 放入字串欄裡面 )
            {
                sb.Append('_');
            }
            else if ( char.IsControl(c) ) // 用  char.IsControl 偵測是否為控制字元，若偵測到式控制字元將其轉換成 CTRL 
            {
                sb.Append("CTRL");
            }
            else if ( c == '-' ) // 偵測是否為 -
            {
                isAfterKebab = true ; // 將 isAfterKebab 狀態改為 true

                // 因為 '-' 後面有可能是 英文字母 or 羅馬字母，所以拿到後面判斷是否為英文和羅馬字母那邊一起做處理。
            }
            else if ( char.IsLetter(c) ) // 偵測是否為英文字母
            {
                if ( c >= 'α' && c <= 'ω' ) // 偵測是否為羅馬字母 (羅馬字母範圍 α ~ ω )
                {
                    continue ; // 如果有羅馬字母則跳過 ( Append 語法的刪除 )
                }

                if ( isAfterKebab ) // 若前一個字元是橫線
                {
                    sb.Append( char.ToUpper(c) ); // 將當下字元變成大寫
                    isAfterKebab = false ;
                }else
                {
                    sb.Append(c); // 如果字串內皆為正常字元，將字元 c 逐一加入( 因為有foreach )
                }
            }
        }

        return sb.ToString(); // 將整理好的字元進行字串轉換後回傳，因為 StringBuilder 不是字串，StringBuilder 類似中間的緩衝區
    }
}
