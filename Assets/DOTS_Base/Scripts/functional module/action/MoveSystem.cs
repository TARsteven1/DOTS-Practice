using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Physics;
//using Unity.Physics.Systems;

public class MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
       // float3 moveVal = new float3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);

        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            if (moveSpeedComponent.MoveSpeed<3)
            {
                return;
            }

            //translation.Value += moveVal * moveSpeedComponent.MoveSpeed * Time.DeltaTime;

            //translation.Value.y += moveSpeedComponent.MoveSpeed * Time.DeltaTime;
            //if (translation.Value.y>5f)
            //{
            //    moveSpeedComponent.MoveSpeed = -math.abs(moveSpeedComponent.MoveSpeed);
            //}            
            //if (translation.Value.y<-5f)
            //{
            //    moveSpeedComponent.MoveSpeed = +math.abs(moveSpeedComponent.MoveSpeed);
            //}
            //Debug.Log(levelComponent.Level);
        });
        Entities.ForEach((ref PhysicsVelocity physicsVelocity, ref MoveSpeedComponent moveSpeedComponent,ref PhysicsCollider physicsCollider) => {
            if (moveSpeedComponent.MoveSpeed>2)
            {
                return;
            }
            
            float3 velocityValue = physicsVelocity.Linear.xyz;
           // velocityValue += moveVal * moveSpeedComponent.MoveSpeed * Time.DeltaTime;
            physicsVelocity.Linear.xyz = velocityValue;
        });
    }
}
