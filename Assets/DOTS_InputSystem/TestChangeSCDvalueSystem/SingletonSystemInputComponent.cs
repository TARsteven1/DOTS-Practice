using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.InputSystem;

public class SingletonSystemInputComponent : ComponentSystem,DOTSControls.ISingletonSystemActions
{
    DOTSControls DOTSplayerActions;
    //EntityQuery entityQuery;
    //float val;
    public void OnAddVal(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            var tscd = GetSingleton<TestSingletonComponentData>();
            tscd.val += 1;
            Debug.Log("+" + tscd.val);
            SetSingleton(tscd);
        }
    }

    public void OnSubVal(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            var tscd = GetSingleton<TestSingletonComponentData>();
            tscd.val -= 1;
            //var val = GetSingleton<TestSingletonComponentData>();
            Debug.Log("-" + tscd.val);
            SetSingleton(tscd);
        }
    }

    protected override void OnUpdate()
    {
        //if (entityQuery.CalculateEntityCount() != 0)
        //{
        //    entityQuery.SetSingleton(new TestSingletonComponentData 
        //    {
        //        val = 1
        //    });
           
        //}
    }
    protected override void OnCreate()
    {
        base.OnCreate();
        DOTSplayerActions = new DOTSControls();
        DOTSplayerActions.SingletonSystem.SetCallbacks(this);
        //entityQuery = GetEntityQuery(typeof(TestSingletonComponentData)); 
        RequireSingletonForUpdate<TestSingletonComponentData>();
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
}
