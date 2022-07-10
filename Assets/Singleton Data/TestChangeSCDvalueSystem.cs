using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.InputSystem;

public class TestChangeSCDvalueSystem : SystemBase/*, DOTSControls.ISingletonDataSystemValueActions*/
{
    //DOTSControls DOTSplayerActions;
    protected override void OnCreate()
    {
        base.OnCreate();
        RequireSingletonForUpdate<TestSingletonComponentData>();

       // DOTSplayerActions = new DOTSControls();
       // DOTSplayerActions.SingletonDataSystemValue.SetCallbacks(this);
    }
    //    public void OnAddVal(InputAction.CallbackContext context)
    //{
    //    var tscd = GetSingleton<TestSingletonComponentData>();
    //    tscd.val += 1;
    //    Debug.Log("+" + tscd.val);
    //    SetSingleton(tscd);
    //}

    //public void OnSubVal(InputAction.CallbackContext context)
    //{
    //    var tscd = GetSingleton<TestSingletonComponentData>();
    //    tscd.val -= 1;
    //    //var val = GetSingleton<TestSingletonComponentData>();
    //    Debug.Log("-" + tscd.val);
    //    SetSingleton(tscd);
    //}


    protected override void OnUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    var tscd = GetSingleton<TestSingletonComponentData>();
        //    tscd.val += 1;
        //    Debug.Log("+" + tscd.val);
        //    SetSingleton(tscd);
        //}
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    var tscd = GetSingleton<TestSingletonComponentData>();
        //    tscd.val -= 1;
        //    //var val = GetSingleton<TestSingletonComponentData>();
        //    Debug.Log("-" + tscd.val);
        //    SetSingleton(tscd);
        //}

    }
}
