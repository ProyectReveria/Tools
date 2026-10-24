# Render System 2D

This Render System was designed for my Metroidvania project, **Reveria**.

It deactivates entire Unity GameObjects when they are outside the render collision area. This disables their components and scripts until the system activates them again.

## How to Use

1. Download the files from this repository.
2. Import them into your Unity project.
3. Attach the render system script to the Player GameObject.
4. Configure the collision components required by the system.
5. Add every GameObject you want the system to manage to the following list:

```csharp
public List<GameObject> allGameobjects_OnUpdateRender = new();
```

This list can contain enemies, visual effects, environmental objects, and other GameObjects that do not need to remain active outside the render area.

6. Assign the required layer references in the Inspector:
   - `Ground_Layer`
   - `DamageEnviorment_Layer`
   - `Player_Layer`

## Initialization

When the system initializes, it deactivates the GameObjects registered in the list. Objects can then be activated or deactivated according to their interaction with the render collision area.

**Important:** Since inactive GameObjects no longer participate in collision events, the system must retain references to them and provide a way to reactivate them when needed.

## Optional Interface

If you want to define custom render-related behavior for your own scripts, you can create and implement an interface such as the following:

```csharp
using UnityEngine;

public interface RMC_Render_Contracts
{
    public void OnEnter_RenderRange()
    {
    }

    public void OnRender_Awake()
    {
    }
}
```

These methods provide optional default implementations. Classes implementing this interface are not required to override them.

Adapt the interface and its methods to your own project's requirements.

## Enjoy!
