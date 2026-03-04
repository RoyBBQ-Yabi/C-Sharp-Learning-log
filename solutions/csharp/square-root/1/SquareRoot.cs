public static class SquareRoot
{
    public static int Root(int number)
    {
        int i = 1; // 從正整數開始計算
        while ( i * i < number) // 當 i 的平方不等於目標數的時候執行迴圈，例如：number==9，i==3 停止
        {
            i++;
        }
        return i; // 迴圈停止後回傳最後 i 的值
    }
}
