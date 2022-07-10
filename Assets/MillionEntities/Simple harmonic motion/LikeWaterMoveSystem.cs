using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class LikeWaterMoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveUpComponentData moveUpComponentData) =>
        {
            float newPosition_z = moveUpComponentData.Pow*(float)math.sin(Time.ElapsedTime * moveUpComponentData.MoveSpeed2 + translation.Value.x*moveUpComponentData.offsetX + translation.Value.y* moveUpComponentData.offsetY);
            translation.Value = new float3(translation.Value.x, translation.Value.y, newPosition_z);

        });
    }

   
}
