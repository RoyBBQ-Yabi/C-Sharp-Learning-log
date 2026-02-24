public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        if( year % 100 != 0 )
        {
            if ( year % 4 == 0)
            {
                return true ; // 無法被 100 整除但可被 4 整除為閨年
            }else
            {
                return false ; // 無法被 100 & 4 整除不是閨年
            }
        }
       else
       {
           if( year % 400 == 0 )
           {
               return true ; // 可被 100 整除且可被 400 整除為閨年
           }else
           {
               return false ; // 可被 100 整除但無法被 400 整除不是閨年
           }
       }
    }
}