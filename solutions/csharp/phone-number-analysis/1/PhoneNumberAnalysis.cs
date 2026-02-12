public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber) 
    //Tuple 宣告，右邊的要拆分成左邊的三個型態並放入，或者按照對應的型態放入像是(true,false,12345)
    {
        string[] parts = phoneNumber.Split("-"); // 先把電話用 split 切開並存入陣列，得到像 ["212", "555", "1234"] 的陣列
        
        bool IsNewYork = parts[0] == "212"; // 陣列判斷各個部分
        bool IsFake = parts[1] == "555";
        string LocalNumber = parts[2];
            
        return (IsNewYork,IsFake,LocalNumber);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake; //回傳先前的 IsFake 值確認結果
    }
}
