public static class Darts
{
    public static int Score(double x, double y) // 三圓判定距離分別為：1、5、10
    {
        double squaredDistance = (x * x) + (y * y); // 使用畢氏定理算出圓形範圍的半徑平方，若要半徑要開根號
        
        if (squaredDistance <= 1) // 沒開根號以距離的平方來做判斷
        {
            return 10;
        }else if (squaredDistance <= 25) // 5 的平方
        {
            return 5;
        }else if(squaredDistance <= 100) // 10 的平方
        {
            return 1;
        }else // 不在範圍內
        {
            return 0;
        }
    }
}
