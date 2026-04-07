public static class Languages
{
    public static List<string> NewList() => new List<String>(); // 建立一個新的 empty list

    public static List<string> GetExistingLanguages() => new List<string> {"C#", "Clojure", "Elm"}; // 事先將題目要求的內容加入進去(非動態)

    public static List<string> AddLanguage(List<string> languages, string language) // 將新的內容加入，使用 .Add() 方法
    {
        languages.Add(language); // 將後續的資料加入至 languages list 當中
        return languages;
    }

    public static int CountLanguages(List<string> languages) => languages.Count; // 計算 list 的欄位數量

    public static bool HasLanguage(List<string> languages, string language) 
    {
        return languages.Contains(language); // 使用 .Contains 檢查特定資料是否存在於 list 當中
    }

    public static List<string> ReverseList(List<string> languages) // 反轉 list
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages) 
    {
        // 如果 C# 在 list 內的第一個位置 or 在第二和三 ( 裡面內容必須至少有2~3種語言 ) 則回傳 true
        
        if (languages.Count == 0) return false; // list 裡面沒有內容，有內容在往下跑
        if (languages[0] == "C#") return true; // 第一個欄位為 C#
        if(languages.Count == 2 && languages[1] == "C#" || languages.Count == 3 && languages[1] == "C#" )
        {
            return true;
        }

        return false; // 上面的條件全都不符合則回傳 false
    }

    public static List<string> RemoveLanguage(List<string> languages, string language) // 移除特定資料
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages) // 檢查內容是否重複
    {
        var uniqueSet = new HashSet<string> (languages); // 將 languages 清單轉成 HashSet ， HashSet 會自動去除重複的資料
        return uniqueSet.Count == languages.Count; // 確認數量是否相同，相同則代表沒有重複
    }
}
