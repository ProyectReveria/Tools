using UnityEngine; 
namespace RMC.StateMachine.States
{
    /// <summary>
    /// This is just the Test Enum of the RMC_StateMachine Library
    /// </summary>
    public class StatesFromDerivation
    {
        public enum StateMachine_States
        {
            None,
            Walking,
            Runing,
            Attacking, 
            Dead, 
            Exception_NonStateFound
        }
    }
}