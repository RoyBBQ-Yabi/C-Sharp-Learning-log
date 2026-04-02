class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() => new[] {0,2,5,3,7,8,4}; // 將先前的每週數量新增至對應陣列

    public int Today() => birdsPerDay[birdsPerDay.Length - 1]; // 抓取 birdsPerDay 陣列的最後一個值並回傳

    public void IncrementTodaysCount()
    {
        birdsPerDay[birdsPerDay.Length - 1] ++; // 將今天的數量 +1
    }

    public bool HasDayWithoutBirds()
    {
        foreach (int count in birdsPerDay) // 檢查陣列哪一個值為 0
        {
            if (count == 0)
            {
                return true;
            }
        }
        return false; // 如果都沒有 0 則回傳 false
    }

    public int CountForFirstDays(int numberOfDays)// 計算本週第一天開始到昨天的來訪數量
    {
        int sum = 0;
        for (int i = 0; i < numberOfDays ; i++) // 利用 for 迴圈進行加總，直到加完前一天的為止
        {
            sum += birdsPerDay[i];
        }
        return sum;
    }

    public int BusyDays() // 尋找數量 >= 5 的天數
    {
        int theBusyDays = 0;
        foreach (int count in birdsPerDay) // 快速翻過陣列中的所有值
        {
            if(count >= 5) 
            {
                theBusyDays ++; // 當有一天的來訪數 >= 5 則繁忙天數 +1
            }
        }
        return theBusyDays; // 回傳迴圈加總後的數量
    }
}
