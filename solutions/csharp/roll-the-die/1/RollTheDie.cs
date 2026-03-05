public class Player
{
    Random rnd = new Random(); // 建立一個通用隨機變數 rnd 可給需要的方法直接調用不用在每個方法裡都建立一個
    public int RollDie()
    {
        /*Random DieNumber = new Random();*/
        return rnd.Next(1,19); 
        
        // Random (min,max)：從 "最小(包含)" 到 "最大(不包含)" 之間隨機取一個數
    }

    public double GenerateSpellStrength()
    {
        /*Random SpellStrength = new Random();*/
        return rnd.NextDouble() * 100.0; 
        
        // Random ()：隨機生成一個整數，Random.NextDouble()：隨機生成一個浮點數 0.0 ~ 0.99
        // 應用Random.NextDouble() * 100 可獲得題目要求的數值範圍 0.0 ~ 100.0
    }
}
