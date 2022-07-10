using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;


public class FollowPlayerSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float3 Player_Pos = float3.zero;
        float4 Player_Rot = float4.zero;

        Entities.ForEach((in Translation translation, in PlayerTag playerTag,in Rotation rotation) =>
        {
            Player_Rot = rotation.Value.value;
             Player_Pos = translation.Value;
        }).Run();
        Entities.WithoutBurst().ForEach((ref Translation translation,ref Rotation rotation, in FollowPlayerTag followPlayerTag) =>
        {
            rotation.Value.value = Player_Rot;
            translation.Value = Player_Pos;
        }).Run();
        Entities.WithoutBurst().ForEach((Transform transform, in FollowPlayerTag followPlayerTag) =>
        {
            Quaternion quaternion = new Quaternion(Player_Rot.x, Player_Rot.y, Player_Rot.z, Player_Rot.w);
            //quaternion.x = Player_Rot.x;
            //quaternion.y = Player_Rot.y;
            //quaternion.z = Player_Rot.z;
            //quaternion.w = Player_Rot.w;

            transform.rotation = quaternion;
            transform.position = Player_Pos;
        }).Run();
    }

  
}
