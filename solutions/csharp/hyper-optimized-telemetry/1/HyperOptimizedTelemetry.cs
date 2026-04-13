public static class TelemetryBuffer
{
     /* 幫資料尋找合適的容器初始為 long，並將裡面的資料 "進行編碼轉換後發送" (BitConverter) */
    public static byte[] ToBuffer(long reading)
    {
        byte prefix; // 建立一個標籤，表示數字是否為負值，並告知後面的資料大小
        byte[] payload; // 建立一個編碼容器裝載數字轉位元組後的資料
        
        // 建立好容器後，開始進行篩檢給予合適大小的容器

        /* 如果數字超過int & uint 的範圍 ( long ) 的話給予最大的容器 byte 256-8 = ( 8 判定正值,248 判定負值 ) */
        if (reading < int.MinValue || reading > uint.MaxValue)
        {
            prefix = (byte)(256-8); // 因為 256-8 後的型態是 int，要塞進 byte 的容器是大轉小，所以要用 (byte) 進行強轉
            
            // 使用 BitConverter 進行位元組轉換，GetBytes 會將 reading 給予的變數型態分別給予符合長度的 byte 陣列
            payload = BitConverter.GetBytes(reading);
        }
        else if (reading > int.MaxValue) /* 數字是正值並且大於int範圍，給予 uint 去判讀 */
        {
            prefix = 4; // 因為是 uint 所以給予 (4 byte) 因為不會有負值所以不寫 (256-4)
            payload = BitConverter.GetBytes((uint)reading); //原先型態為 long 所以要強轉成 uint
        }
        else if (reading < short.MinValue || reading > ushort.MaxValue) // 區間位於 (int) 的範圍
        {
            prefix = (byte)(256-4);
            payload = BitConverter.GetBytes((int)reading);
        }
        else if (reading < 0) /* 範圍包含在 short、int、long 裡面，代表值在 short 的範圍裡面 */
        {
            prefix = (byte)(256-2); // 給予最小的容器，由於數字為負值所以使用 (256-2) 來表示負值
            payload = BitConverter.GetBytes((short)reading);
        }else
        {
            prefix = 2; // 在 short 裡面並且為正值，所以以 2 表示正值
            payload = BitConverter.GetBytes((ushort)reading); // ushort 不包含負值所以給予此型態
        }

        /* 進行裝箱：準備一個 9 個空間的緩衝區 */
        byte[] buffer = new byte[9];
        buffer[0] = prefix; // 將標籤放在第 0 個位置

         /* 將轉換後的資料複製到緩衝區，從第 1 格開始放 */
        Array.Copy(payload, 0, buffer, 1, payload.Length); 
        // 語意：從 payload 第 0 開始取件然後搬到 buffer 的第 1 格， payload.Length 表示有幾個東西
        
        return buffer;
    }

    public static long FromBuffer(byte[] buffer) /* 將接收到的資料進行編碼轉成 "原本的資料型態和樣貌" ，並給予合適的容器 */
    {
        byte prefix = buffer[0]; // 先從緩從區的第 0 格標籤來選擇解讀內容
        return prefix switch
        {
            2   => BitConverter.ToUInt16(buffer, 1), // 標籤 2：用 ushort 解讀，從第 1 格開始讀 ( 因為第 0 格式是標籤後面才是真正的內容)
            254 => BitConverter.ToInt16(buffer, 1),  // 標籤 254：用 short 解讀
            4   => BitConverter.ToUInt32(buffer, 1), // 標籤 4：用 uint 解讀
            252 => BitConverter.ToInt32(buffer, 1),  // 標籤 252：用 int 解讀
            248 => BitConverter.ToInt64(buffer, 1),  // 標籤 248：用 long 解讀
            _   => 0
        };
    }
}
