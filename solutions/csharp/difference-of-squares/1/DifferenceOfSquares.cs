public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max)
    {
        int sum = max *( max +1 ) / 2 ; // 計算（1 + 2 + ... + n）² 公式是：[n*(n+1)/2]²
        return sum * sum ;
    }

    public static int CalculateSumOfSquares(int max) => max * ( max + 1 ) * ( 2 * max + 1 ) / 6;
    // 計算  1² + 2² + ... + n² 公式是：ｎ*(n+1)(2n+1)/6

    public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    // 計算兩者的平方差
}