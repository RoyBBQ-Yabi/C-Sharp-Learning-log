abstract class Character
{
    string _characterType; // 將職業名稱儲存起來
    protected Character(string characterType) // : base("characterType")  會優先傳到這邊
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target); // 抽象方法，因為每個職業的傷害判定不同所以 "父類別只定義名字"

    public virtual bool Vulnerable() => false; // 預設角色不處於易傷狀態

    public override string ToString() => $"Character is a {_characterType}"; 
        // 描述該角色職業
        // characterType 執行完後消失所以要用 _characterType 裡的資料
}

class Warrior : Character
{
    public Warrior() : base("Warrior") 
    {
        // 尋找符合條件的父類別方法並匯入 Warrior 資料 => protected Character(string characterType){}
        // 邏輯：由於使用了 : base() ，所以他會先去找對應的建構子 "名稱&(型態) 皆符合" 的才會匯入，沒有符合的則會報錯
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable() ? 10 : 6; // true : false (if-else 的另一種寫法)
        
        /*  if (target.Vulnerable() == true) 
            {
                return 10;
            }else {
                return 6;
            }*/
    }
}

class Wizard : Character
{
    bool _isSpellPrepared = false; // 先預設巫師不處於師法狀態
    
    public Wizard() : base("Wizard")
    {
    }

    public void PrepareSpell() // 巫師以處於師法狀態則呼叫此方法並將狀態改為 true
    {
        _isSpellPrepared = true;
    }
    
    public override int DamagePoints(Character target) // 確認狀態並給予傷害判定
    {
        return _isSpellPrepared ? 12 : 3;
    }

    public override  bool Vulnerable() => !_isSpellPrepared; 
    // 如果師法狀態是 false 則易傷狀態則是 true ，所以使用 !_isSpellPrepared 來判定  
}
