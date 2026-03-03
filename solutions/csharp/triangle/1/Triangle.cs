public static class Triangle
{
    // 等邊：三邊相等、等腰：至少兩邊相等、不等邊：三邊不相等

    public static bool IsValid (double side1, double side2, double side3) // 判定能否組成三角形
    {
        return side1 > 0 && side2 > 0 && side3 > 0 && (side1 + side2 >= side3)  && (side1 + side3 >= side2) && (side2 + side3 >= side1);
    }
    
    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (IsValid(side1, side2, side3))
        {
            return side1 != side2 && side2 != side3 && side1 != side3; // 都不相等
        }else return false;
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
         if (IsValid(side1, side2, side3))
         {
             return side1 == side2 || side2 == side3 || side1 == side3; // 至少兩邊相等
         }else return false;
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        if (IsValid(side1, side2, side3))
        {
            return side1 == side2 && side2 == side3; // 三邊皆相等
        }else return false;
    }
}