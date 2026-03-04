public static class RomanNumeralExtension
{
    public static string ToRoman(this int value) // 羅馬數字換算可用於：金錢的面額轉換功能、階級表示美化 (FFXIV等) ......
    {
        // 從最大的值先去扣除 (貪婪演算法)：1999 順序為：大於1000?　大於則扣除、扣除後大於900?、依此類推
        
        // 定義數字的陣列，大至小，羅馬數字規則：同一符號不可出現超過四次，左到右一定是大到小
        int [] Value = {1000,900,500,400,100,90,50,40,10,9,5,4,1};
        string [] Roman = {"M","CM","D","CD","C","XC","L","XL","X","IX","V","IV","I"};

        string ToRoman = ""; // 結果字串 ( 預設為空 )

        for( int i = 0 ; i < Value.Length ; i++) //用 for 迴圈計算現在的數字是多少，讓i從最大值開始
        {
            while( value >= Value[i] ) // 當目標數字還沒扣光就繼續 (1999)
            {
                ToRoman += Roman[i]; // 將當下 i 結果對應到對應的羅馬數字後，儲存字串並用 += 組合起來 (M+CM+XC+V+I)
                value -= Value[i]; // 當下目標數字扣除對應的陣列數字 (1999-1000,999-900,99-90...)
            }
        }
        return ToRoman; // 回傳組合後的羅馬數字 ( MCMXCVI )
    }
}