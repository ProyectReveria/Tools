using UnityEngine;

namespace UnityEngine.Obscure_Framework.Game_Math; 

public static class ObscureMath 
{
    private static readonly System.Random _Sran_ = new System.Random(); 
    public static double incrementalXP(double xp_i,double xp_f) => (xp_f - xp_i / xp_i) * 100; 
    public static double inflation(double Current_CPI, double Previous_CPI) => (Current_CPI - Previous_CPI / Previous_CPI) * 100; 
    public static double CPI_Calculation_base(double Cost_of_Item_Now, double Cost_of_item_LastTime) => (Cost_of_Item_Now / Cost_of_item_LastTime) * 100; 
    public static double _Damage_DPS_ (double damage, double attackspeed) => damage / attackspeed; 
    public static double _Damage_On_DPSTreshole (double damage, double dps)
    {
        double min = (Math.Min (damage,dps));
        double max = (Math.Max (damage,dps));


        return _Sran_.NextDouble() * (max-min) + max; 
    }
    public static double Crit_Change_Calculation_Or_CritDamage(double base_crit_chance, double aditive_Crit) => base_crit_chance * (1+aditive_Crit);
}
