class RemoteControlCar
{
    // 設定遙控車基礎參數設定，不可被公用更改
    private int _totalDistance = 0;
    private int _batteryPower = 100;
    
    public static RemoteControlCar Buy() 
    {
        return new RemoteControlCar(); // 生產一台遙控車的產線 ( 若有複數車輛需分別給予不同名稱：var blueCar = RemoteControlCar Buy() )
    }

    public string DistanceDisplay()
    {
        return $"Driven {_totalDistance} meters" ; // 回傳 "里程數" 並顯示出來
    }

    public string BatteryDisplay()
    {
        if( _batteryPower == 0) // 電池為 0 時顯示 Battery empty
        {
            return "Battery empty" ;
        }
        return $"Battery at {_batteryPower}%" ; // 回傳 "剩餘電池電量" 並顯示出來
    }

    public void Drive() // 題目給予 "車輛每行駛 20m 消耗 1% 的電量"
    {
        if ( _batteryPower > 0) // 只有電池電量 > 0 才繼續行駛
        {
            // ( 先跑再耗電 )
            _totalDistance += 20; // 當還有電時：車輛行駛 20m，里程數增加 20m
            _batteryPower -= 1; // 當還有電時：每行駛 20m 掉 1% 電量            
        }
    }
}
