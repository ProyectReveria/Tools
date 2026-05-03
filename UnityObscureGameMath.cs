using UnityEngine;
using System;
using System.Numerics;


///<summary>
/// Hello! Welcom to one's Again Rosary obscure tools, at this point is my personal way to tell "I MAKE THIS"
/// In this case is actually useable whit unity, just DO NO change how the namespace behavior, unity do not use Cs readfiles
/// each formula is the matematical standar of each one. 
/// in the case of Crit_change is actualy use also has CritDamage formula, becose is tecnecly the same formula.
/// 
/// Postada: is on the Disel Engine Logic, is posible is not precises becose of how LUA behaivor whit the data, if this generate one problem
/// just use the formulas from the Lua RosesBalance Framework.
/// </summary>
namespace UnityEngine.Obscure_Framework.Game_Math
{
    /// <openSource Limits>
    ///     Give Me credits ty.
    /// </end of openSource Limits>
    
    public static class ObscureMath
    {
    private static int ClampLimitAlfa = 0; 
    private static int ClampLimitBeta = 1; 

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
    public static bool _DogeProb_(double dodgeChance) => _Sran_.NextDouble() *100 < dodgeChance; 
    public static double _DamageReducted_ (double damage, double reduction) => damage * (1 - Math.Clamp(reduction, ClampLimitAlfa,ClampLimitBeta)); 

    public static double _DoT_Total(double Tick_Damage, double duration, double interval) => (duration/interval) *Tick_Damage; 
    public static double _Calculate_MultiplicatorOnCrit(double @base, double baseMultiplayer, double Multiplier) => @base * (baseMultiplayer + baseMultiplayer);

    }
}
