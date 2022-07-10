using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using UnityEngine.InputSystem;

public class VisibilityChangeSystem : SystemBase/*, DOTSControls.IVisibilitySystemActions*/
{
    //DOTSControls DOTSplayerActions;
    //public void OnDisable(InputAction.CallbackContext context)
    //{
    //    Entities.WithoutBurst().WithStructuralChanges().ForEach((in Entity entity,/*in DisableComponentTag disableComponentTag,*/in Disabled disabled, in PlayerTag playerTag) => {
    //        EntityManager.RemoveComponent<Disabled>(entity);
    //    }).Run();
    //}

    //public void OnEnable(InputAction.CallbackContext context)
    //{
    //    Entities.WithoutBurst().WithStructuralChanges().ForEach((in Entity entity/*in DisableComponentTag disableComponentTag,*//*in PlayerTag playerTag*/ ) => {
    //        EntityManager.SetEnabled(entity, false);
    //    }).Run();
    //}

    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //按组件标签disable entity
            Entities.WithoutBurst().WithStructuralChanges().ForEach((in Entity entity/*in DisableComponentTag disableComponentTag,*//*in PlayerTag playerTag*/ ) =>
            {
                EntityManager.SetEnabled(entity, false);
            }).Run();
        }
        if (Input.GetKeyDown(KeyCode.R))
        { //按组件标签SetEnable entity
            Entities.WithoutBurst().WithStructuralChanges().ForEach((in Entity entity,/*in DisableComponentTag disableComponentTag,*/in Disabled disabled, in PlayerTag playerTag) =>
            {
                EntityManager.RemoveComponent<Disabled>(entity);
            }).Run();
        }
    }
    //protected override void OnCreate()
    //{
    //    base.OnCreate();
    //    DOTSplayerActions = new DOTSControls();
    //    DOTSplayerActions.VisibilitySystem.SetCallbacks(this);

    //}



}
