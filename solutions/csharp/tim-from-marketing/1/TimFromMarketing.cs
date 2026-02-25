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
