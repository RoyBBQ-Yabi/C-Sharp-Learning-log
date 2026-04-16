public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        // 設定頭跟尾
        int left = 0; 
        int right = input.Length - 1;

        while( left <= right ) // 還沒找到目標就將全部數字找過一輪 ( <= 能將最後的一個數字防止漏掉，因最後一個數字頭跟尾位置皆相同 )
        {
            int mid = (left + right) / 2; // 設定中間位置

            if ( input[mid] == value) // 找到目標
            {
                return mid;
            }else if ( input[mid] < value ) // 目標比中間大，往右邊找，頭邊中間 +1 的值 ( 因為中間不是目標 )
            {
                left = mid + 1;
            }else if ( input[mid] > value ) // 目標比中間小，往左邊找，尾便中間 -1 的值
            {
                right = mid - 1;
            }
        }
        return -1 ; // 跳出迴圈 ( 其餘情況 ) 回傳 -1
    }
}