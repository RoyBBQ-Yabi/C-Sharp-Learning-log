class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven() => 40; //定義烤箱時間

    // TODO: define the 'RemainingMinutesInOven()' method

    public int RemainingMinutesInOven(int timeInOven ) => ExpectedMinutesInOven() - timeInOven; //抓取先前烤箱預設時間方法並扣除已建立時間變數

    // TODO: define the 'PreparationTimeInMinutes()' method

    public int PreparationTimeInMinutes(int layerTime) => layerTime * 2; //PreparationTimeInMinutes 變數會=層數*2分鐘 以計算放入烤箱前的準備時間

    // TODO: define the 'ElapsedTimeInMinutes()' method
  public int ElapsedTimeInMinutes(int numberOfLayers, int minutesInOven)
    {
        int preparationTime = PreparationTimeInMinutes(numberOfLayers);
        int totalTime = preparationTime + minutesInOven;
        return totalTime;
    } 
}
