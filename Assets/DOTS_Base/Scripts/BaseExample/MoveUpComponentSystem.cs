using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Mathematics;

public class MoveUpComponentSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltatime= Time.DeltaTime;
        //throw new System.NotImplementedException();
        return Entities.ForEach((ref Translation translation, ref MoveUpComponentData moveUpComponentData) =>
         {

             translation.Value.x += moveUpComponentData.MoveSpeed2 * deltatime;
             translation.Value.y += moveUpComponentData.MoveSpeed2 * deltatime;
             //if (translation.Value.y > 5f)
             //{
             //    moveUpComponentData.MoveSpeed2 = -math.abs(moveUpComponentData.MoveSpeed2);
             //}
             //if (translation.Value.y < -5f)
             //{
             //    moveUpComponentData.MoveSpeed2 = +math.abs(moveUpComponentData.MoveSpeed2);
             //}
         }).Schedule(inputDeps);
    }
}
