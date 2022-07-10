using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class PlayerControlSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        float t = Time.DeltaTime;
        float angle = 0;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Entities.WithAll<PlayerTag>().ForEach((ref Translation translation, ref PlayerTag playerTag) =>
            {
                translation.Value += new float3(0, 0, 1) * t * playerTag.Speed;
            });
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Entities.WithAll<PlayerTag>().ForEach((ref Translation translation, ref PlayerTag playerTag) =>
            {
                translation.Value += new float3(0, 0, -1) * t * playerTag.Speed;
            });
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Entities.WithAll<PlayerTag>().ForEach((ref Translation translation, ref PlayerTag playerTag) =>
            {
                translation.Value += new float3(-1, 0, 0) * t * playerTag.Speed;
            });
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Entities.WithAll<PlayerTag>().ForEach((ref Translation translation, ref PlayerTag playerTag) =>
            {
                translation.Value += new float3(1, 0, 0) * t * playerTag.Speed;
            });
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            Entities.WithAll<PlayerTag>().ForEach((ref Rotation rotation, ref PlayerTag playerTag) =>
            {
                // rotation.Value.value.z +=1 * t * playerTag.Speed;
                //Quaternion.Slerp(rotation, targetRotation, Time.deltaTime);
                angle = 20 * t;
                rotation.Value.value.y = math.sin(angle * 0.5f);//待解决
                //rotation.Value.value = new float4(0, 1, 0, 0)* math.sin(t * playerTag.Speed );
            });
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Entities.WithAll<PlayerTag>().ForEach((ref Rotation rotation, ref PlayerTag playerTag) =>
            {
                //rotation.Value.value.w += -1* t * playerTag.Speed;
                //angle -= 20*t;
                //rotation.Value.value.y = math.sin(angle / 2);
                rotation.Value.value = new float4(0, -1, 0, 0) * math.sin(t * playerTag.Speed);
            });
        }

    }

}
