using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

namespace ObscureEngine_ForUnity.Manual__DeltaTime
{
    internal class __Manual__DeltaTime
    {
        public static float _DeltaData_Run {get; private set;}
        public static void __Delta_Time__(double Dtime)
        {
            double __deltatime_speed = 2;
            double Delta_Time_Movement = __deltatime_speed * Dtime; 
        }

        public static void __Run__DeltaTime(bool __UnityEngine__ConfirmManualDelta__)
        {
            Stopwatch DWatch = new Stopwatch(); 
            DWatch.Start(); 
            
            double S_Frame = 0; 

            while (__UnityEngine__ConfirmManualDelta__ == true)
            {
                //For Cicles
                double __GPU__Cicle_ = DWatch.ElapsedTicks; 
                double __GPU__Status = __GPU__Cicle_ - S_Frame; 

                //For Normal Delta Time
                double __Seg__Cicle = DWatch.Elapsed.TotalSeconds; 
                double __Seg__Status = __Seg__Cicle - S_Frame; 

                __Delta_Time__(__Seg__Status); 

                if (__Seg__Status< 0.0166666666666666666667)
                {
                    Thread.Yield();
                }
                
            }

            if (__UnityEngine__ConfirmManualDelta__ == false)
            {
                Console.WriteLine("Manual Delta Time Fail becose unity Sincronization is not confirm"); 
            }
        }


    }
}
