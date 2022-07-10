using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine.InputSystem;
[UpdateBefore(typeof(MoveComponentSystem_IS))]
public class PlayerInputSystemComponent : ComponentSystem, DOTSControls.IDOTSplayerActions
{
    DOTSControls DOTSplayerActions;
    EntityQuery entityQuery;
    Vector2 PlayerMoveDirection;
    bool jump;
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase==InputActionPhase.Performed)
        {
        PlayerMoveDirection= context.ReadValue<Vector2>();

        }
    }

    protected override void OnUpdate()
    {
        if (entityQuery.CalculateEntityCount()!=0)
        {
            entityQuery.SetSingleton(new MoveComponentData_IS { 
            MoveDirection=new float3(PlayerMoveDirection.x,0, PlayerMoveDirection.y),Speed=2f,
                isJump = jump
        });
            jump = false;
        }

    }    
    protected override void OnCreate()
    {
        base.OnCreate();
        DOTSplayerActions =new DOTSControls();
        DOTSplayerActions.DOTSplayer.SetCallbacks(this);
        entityQuery = GetEntityQuery(typeof(MoveComponentData_IS));
    }    
    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        DOTSplayerActions.Enable();
        
    }    
    protected override void OnStopRunning()
    {
        base.OnStopRunning();
        DOTSplayerActions.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            jump = true;
        }
    }
}
