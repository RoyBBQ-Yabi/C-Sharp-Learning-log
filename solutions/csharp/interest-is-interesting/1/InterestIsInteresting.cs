static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        if ( balance < 0 )
        {
            return 3.213f; // 注意實際利率 3.213 "%"
        }else if( balance < 1000 )
        {
            return 0.5f;
        }else if( balance < 5000 )
        {
            return 1.621f;
        }else
        {
            return 2.475f;
        }
    }

    public static decimal Interest(decimal balance) => balance * (decimal)InterestRate(balance) / 100;
    // 先前的利率 "未計算百分比" 部分所以要除以 100    

    public static decimal AnnualBalanceUpdate(decimal balance) => balance + Interest(balance);
    // 計算加完利息後的總餘額

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0; // 計算當前經過幾年
        decimal currentBalance = balance; // 計算含利息後的正確餘額
        
        while (currentBalance < targetBalance) // 利用迴圈計算 "複利"
        {
            currentBalance = AnnualBalanceUpdate(currentBalance); // 抓取方法三的總餘額進行迴圈計算 "直到抵達目標金額"
            years++; 
        }
        
        return years;
    }
}
