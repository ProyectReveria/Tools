using System;
using System.Collections.Generic;
using UnityEngine;

using RMC.StateMachine.States;
using Unity.VisualScripting;


/// <summary>
/// Brain
/// 
/// This is the State Machine Brain abstract, this control the States order in the Machine
/// 
/// This imply if :
/// 
///  Astate in Dictionary of (Astate, StateMachine<Astate>) will execute the Astate from the StateMachine Itself. 
/// 
/// This also have has dependency the RMC_StateMachine.CS
/// </summary>
/// <typeparam name="Estate"></typeparam>
public class RMC_StateBrain <Estate> : MonoBehaviour where Estate : Enum 
{
    #region Referencial Data

    protected Dictionary<Estate , RMC_StateMachine<Estate>> State_DicList = new Dictionary<Estate,RMC_StateMachine<Estate>>();

    protected RMC_StateMachine<Estate> _Current_State;
    protected bool IsTransitionState = false;

    #endregion
    #region Unity Update

    void Start()
    {
        _Current_State.EnterState();

        
    }

    void Update()
    {

        Estate nexStateKey = _Current_State.GetNextState();

        if (nexStateKey.Equals(_Current_State.StateKey))
        {
            _Current_State.UpdateState();
        }else if (!IsTransitionState)
        {
            TransitionToState(nexStateKey);            
        }
    }
    /// <summary>
    /// TransitionToState clear the State before changing the StateMachine State.
    /// 
    /// this sound confusion but is just change from one action to another porperly
    /// </summary>
    /// <param name="StateKey"> _current_state </param>
    public void TransitionToState(Estate StateKey)
    {
        IsTransitionState = true;
        _Current_State.ExistState();
        _Current_State = State_DicList[StateKey];
        _Current_State.EnterState();
        IsTransitionState = false;
    }

    //-- Triggers -- 

    void OTriggerEnter(Collider other)
    {
        _Current_State.OTriggerEnter(other);
    }

    void OnTriggerStay(Collider other)
    {
        _Current_State.OnTriggerStay(other);
    }

    void OnTriggerExit(Collider other)
    {
        _Current_State.OnTriggerExit(other);
    }

    #endregion
}
