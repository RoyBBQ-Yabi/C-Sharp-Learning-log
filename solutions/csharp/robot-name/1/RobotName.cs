public class Robot
{
    static HashSet<string> allName = new HashSet<string> (); // 先建立一個名字清單，並用 HashSet 去過濾重複的名字
    static Random rng = new Random(); // 建立一個隨機型態
    string name ; // 建立名字字串 (供清單使用)
    
    public string Name
    {        
        get // 啟動機器人時確認有無名字，沒有則給予一個
        {
            if (name == null)
            {
                string botName; // 給機器人使用的名字字串
                do
                {
                    char c1 = (char) rng.Next('A','Z' +1); // 在第一個字隨機生成 A~Z，使用 +1 才能生成 Z 否則只會是 A~Y
                    char c2 = (char) rng.Next('A','Z' +1); // 將字母轉換成 cahr 否則會因為 ASCll 變成數字
                    
                    botName = $"{c1}{c2}{rng.Next(1000):D3}"; // 給予機器人名字(前二大寫英文，後三三個數字)， :D3 表示當數字不滿三位時補 0
                        
                }
                while ( allName.Contains(botName) ); // 使用 Contains 檢查 botName 是否已存在 allName 中，存在代表該名字以重複
                name = botName; // 若該名字可以使用，跳到這段給予機器人新名字
                allName.Add(name); // 將新名字加入至清單當中
            }
            return name;
        }
    }

    public void Reset()
    {
        name = null; // 將名字重設直接變成 null 狀態即可
    }
}