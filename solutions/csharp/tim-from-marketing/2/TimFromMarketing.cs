static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string upperDept = (department?? "OWNER").ToUpper(); // 將部門名稱轉為大寫，若部門名稱為空則給予 OWNER 標籤

        if ( id == null )
        {
            return $"{name} - {upperDept}"; 
        }else{
            return $"[{id}] - {name} - {upperDept}"; // 輸出胸牌標籤樣式 ID 以 [] 框住
        }
    }
}

// ? 表示此類別可為空值的標籤。
// ?? 類似 if-else "不是空" 直接輸出，"是空" 則輸出 ?? 右邊的值。
// ?. 表示當類別的值 "為空的時候" 停止執行，"不是空的時候" 才執行右邊的指令
