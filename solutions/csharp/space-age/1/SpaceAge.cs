public class SpaceAge
{
    
    double ageSec ; // 建立一個 double 變數儲存秒數，以利後續計算
    double earrhYearSec = 31557600.0 ; // 建立一個公用計算變數 (地球一年的秒數)
    
    public SpaceAge(int seconds) // 存活年紀 (秒數)
    {
        ageSec = (double)seconds;
    }

    public double OnEarth() // 在地球的年紀 ( 秒數 / 地球一年秒數 = 實際歲數 )
    {
        return ageSec / earrhYearSec; 
    }

    public double OnMercury() // 水星轉一圈，地球轉 0.24 圈，所以將 ( 年齡 / 倍數 )即可，後面以此類推
    {
        return OnEarth() / 0.2408467; 
    }

    public double OnVenus()
    {
         return OnEarth() / 0.61519726; 
    }

    public double OnMars()
    {
         return OnEarth() / 1.8808158; 
    }

    public double OnJupiter()
    {
         return OnEarth() / 11.862615; 
    }

    public double OnSaturn()
    {
         return OnEarth() / 29.447498; 
    }

    public double OnUranus()
    {
         return OnEarth() / 84.016846; 
    }

    public double OnNeptune()
    {
         return OnEarth() / 164.79132; 
    }
}