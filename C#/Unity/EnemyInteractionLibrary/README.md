# Enemy Movement Library

This library contains **2D Unity code only**.

## How to use

1. Download both C# files (excluding this README):
   - `EnemyDamage Interface.cs`
   - `EnemyMovement_Abstraction_Convencions.cs`
2. Add both files to your Unity project.
3. Create a new C# script.
4. Make your class inherit from `Enemy_Movement_BaseBahivior`:

```csharp
public class Test_Class : Enemy_Movement_BaseBahivior
{
}
```

## Dependencies

This script requires an `EnemyStats` implementation.

The test struct is included in this repository. If you use a different stats system, you only need to adapt the parts of the code that access your enemy's statistics.

For example, replace the following method with one that retrieves the equivalent values from your own stats system:

```csharp
protected virtual void UpdateData()
{
    // DO NOT PUT THIS IN FixedUpdate.
    Enemy_Position = Enemy.transform.position;

    HPStatus_Enemy = Enemy_Stats.T_U_P_C.EnemyHP;
    acceleration = Enemy_Stats.T_U_P_C.Enemy_Aceleration;
    _edgedetection = Enemy_Stats.T_U_P_C.Enemy_LedgeCheckoofset;
    _velocity = Enemy_Stats.T_U_P_C.Enemy_Speed;
}
```

The movement system requires the following references and settings:

```csharp
[SerializeField] protected EnemyStats Enemy_Stats;
[SerializeField] protected Collider2D bodyCollider;
[SerializeField] protected Collider2D FeetCollider;
[SerializeField] protected GameObject Enemy;
[SerializeField] protected Rigidbody2D Enemy_Rickbody;

[Range(0f, 1f)]
public float Enemy_MoveThreshold = 0.25f;

[SerializeField] protected bool _RigthView;
protected Vector2 Enemy_Position;
protected Vector2 EnemyGravity;
[SerializeField] protected LayerMask floor;

[SerializeField, Range(0.1f, 0.6f)]
protected float EnemyTimeMoving = 0.1f;

[SerializeField] protected float WallCheckDistance = 0.1f;
```

Assign the required references in the Unity Inspector. You can also adjust fields with a `Range` attribute using the Inspector sliders.

The remaining variables are internal movement parameters used by the system.

**Important:** Make sure your floor layer and colliders are configured correctly. Otherwise, the enemy may not move as expected.

# Enjoy!
