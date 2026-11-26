using UnityEngine;
using RMC.StateMachine.States;
using System;

/// <summary>
/// From RMC Library Execute this has the State Machine Manager in Abstract context.
/// This also include the methods to Enter,Exit,Update and Get the next state having has dependency the RMC_StateBrain.cs from Library
/// </summary>
/// <typeparam name="Estate"> Estate Enum whit all the State Special Cases from the State Procedural Machine</typeparam>
public abstract class RMC_StateMachine <Estate> where Estate : Enum 
{
    // --Declare Keys -- 

    public RMC_StateMachine(Estate key)
    {
        StateKey = key;
    }

    public Estate StateKey {get;private set;}

    // -- Change States
    public abstract void EnterState();
    public abstract void ExistState();
    public abstract void UpdateState();
    public abstract Estate GetNextState();
    // -- Triggers -- 
    public abstract void OTriggerEnter(Collider other);
    public abstract void OnTriggerStay(Collider other);
    public abstract void OnTriggerExit(Collider other);
}
