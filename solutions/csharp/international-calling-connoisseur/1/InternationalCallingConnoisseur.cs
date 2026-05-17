public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() => new Dictionary <int, string>();
    // 建立一個新的空 Dictionary

    public static Dictionary<int, string> GetExistingDictionary() // 加入預設資料
    {
        return new Dictionary <int, string> // 回傳 Dictionary (包含裡面的資料一起)
        {
            [1] = "United States of America",
            [55] = "Brazil",
            [91] = "India"
        };
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        // 將輸入的 key、Value 塞進新的 Dictionary 中
        var dict = new Dictionary <int, string>(); 
        dict[countryCode] = countryName; // 塞入資料寫法
        return dict;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        // 將新資料加入至已有資料的 Dictionary (existingDictionary)中，Dictionary<int, string> 為型別宣告類似 (int)
        // 和上題寫法一樣
        existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        // 使用 key 查找資料，如果找不到對應的 key 則回傳：空字串。
        if ( existingDictionary.ContainsKey(countryCode) ) // 回傳 bool 值，true 直接進入 if
        {
            return existingDictionary[countryCode]; // 回傳 key 對應的國家
        }
        return string.Empty; // 如果沒有找到對應的 key 回傳空字串，以防止程式出錯
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode) 
    {
        // 檢查有無資料 (同上題)
        return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        // 更新 Dictionary 的資料，若無資料則保持原樣
        // 使用 ContainsKey 檢查，true 更新，false 原樣
        if ( existingDictionary.ContainsKey(countryCode) )
        {
            existingDictionary[countryCode] = countryName; 
        }
        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        // 使用 key 刪除 key(包含) 指定的資料
        existingDictionary.Remove(countryCode); // 使用 .Remove(key) 移除資料
        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        // 找出名字最長的國家，因為 Dictionary 是一個 雜湊儲存的 所以用 foreach 找會比較適合
        string longestName = "";
        foreach ( string name in existingDictionary.Values )
        {
            if ( name.Length > longestName.Length ) // 比較長度
            {
                longestName = name;
            }
        }
        return longestName;
    }
}