using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
[UpdateAfter(typeof(PlayerInputSystemComponent))]
public class MoveComponentSystem_IS : ComponentSystem
{
    protected override void OnUpdate()
    {
        float t = Time.DeltaTime;
        Entities.ForEach((ref Translation translation, ref MoveComponentData_IS moveComponentData_IS) =>
        {
            translation.Value += moveComponentData_IS.Speed* moveComponentData_IS.MoveDirection *t;
           // Player_Pos = translation.Value;
        if (moveComponentData_IS.isJump==true)
        {
                translation.Value += new float3(0, 2, 0);
                moveComponentData_IS.isJump = false;
        }
        });
    }

    
}
