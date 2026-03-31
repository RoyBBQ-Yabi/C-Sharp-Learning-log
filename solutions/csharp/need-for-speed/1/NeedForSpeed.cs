class RemoteControlCar
{
    // 定義一台遙控汽車的基本數值
    public int _speed; // 行駛速度
    public int _batteryDrain; // 電池消耗量
    public int _distance = 0; // 行駛總距離
    public int _batteryRemaining = 100; // 剩餘電量

    public RemoteControlCar(int speed , int batteryDrain ) // 建構一個創建遙控車的和函式 (速度，電池消耗量)
    {
        _speed = speed;
        _batteryDrain = batteryDrain; // 給予新的電池消耗量
    }
    
    public bool BatteryDrained() => _batteryRemaining < _batteryDrain; // 判斷電池是否耗盡

    public int DistanceDriven() => _distance; // 回傳目前行駛距離的值
    
    public void Drive()
    {
        if (_batteryRemaining >= _batteryDrain) // 電量 > 消耗量就繼續跑
        {
            _distance += _speed; // 距離 = 原距離+速度
            _batteryRemaining -= _batteryDrain; // 電量 = 現在電量 - 電池消耗量
        }
    }

    public static RemoteControlCar Nitro() // 製作最暢銷車款 Nitro，速度為 50 ，電池消耗為 4%
    {
        return new RemoteControlCar(50,4); // 抓取先前的 RemoteControlCar 函示並給予指定數值，並將其訂製為 Nitro 的固定參數 ( 因為會常用到 )
    }
}

class RaceTrack
{
    int raceDistance ; // 先給予一個賽道距離

    public RaceTrack (int distance) // 賽道建構函式
    {
        raceDistance = distance; 
    }
    
    public bool TryFinishTrack(RemoteControlCar car) //確認車輛是否能完賽，並且該函式已將RemoteControlCar定義為 car 方便抓取上面的函示
    {
        // 檢查該車的電量是否還夠並且剩餘距離為多少 or 直接計算該車能跑多長的距離並決定回傳 true or fasle
        // 假設一台車 50 km/h ，消耗量為 5% ， 能夠行駛的總距離為：100/5= 20 => 20*50= 1000 km
        // 賽道距離 - 能夠行駛的總距離 = 0 or 負值則完賽，大於 0 則表示未完賽

        int batteryTimes = 100 / car._batteryDrain; // 在電量 100% 的情況下，會進行幾次的電量消耗
        int maxDistancd = batteryTimes * car._speed; // 電量總消耗次數 * 速度 = 最大行駛距離

        return maxDistancd >= raceDistance ; // 如果最大行駛距離 >= 賽道距離則表示 true ，即為完賽
    }
}
