public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch // 新版 switch 寫法
        {
                // 將 case(value) 變成 "=>" 表示
                // 捨去 break，每行間格已 "," 表示
                // default 變成 “_”
                // 右大括號後加入 ";" 結束 switch
                
                1 => "goalie", 
                2 => "left back",
                3 or 4 => "center back",
                5 => "right back",
                6 or 7 or 8 => "midfielder",
                9 => "left wing",
                10 => "striker",
                11 => "right wing",
                _ => "UNKNOWN"
        };
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int count : // 如果值是 int 將內容存入 count
                return $"There are {count} supporters at the match.";
                
            case string Announcements : // 如果是字串就存入 Announcements
                return Announcements; // 輸出字串，本來就是字串直接輸入變數名稱即可

            case Injury injury: // 建立特殊事件 (犯規、受傷、其他) 並需要 標示背號 的事件
                return $"Oh no! {injury.GetDescription()} Medics are on the field."; //題目給的程式碼已有 GetDescription() 將其調用即可

            case Incident incident : // 處理其餘的事件
                return incident.GetDescription(); // 同 injury 的 return 寫法

            case Manager m when m.Club != null: // 描述經理名字和俱樂部名稱，建立 Manager 類別並用 when 篩選有 ClubName 的經理
                return $"{m.Name} ({m.Club})";
                
            case Manager m: // ClubName 未知，輸出經理名稱即可
                return m.Name;
                
            default :
                return ""; //都不是就回傳空字串
        }
    }
}
