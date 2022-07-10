using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;

public class TestTriggerEventSystem : SystemBase
{
    public BeginInitializationEntityCommandBufferSystem beginInitializationEntityCommandBufferSystem;
    private struct TriggerJob : ITriggerEventsJob
    {
        //PhysicsVelocity只有添加了PhysicsBodyAuthoring才会被添加到Entity，意味着我们可以以此来过滤小球
        public ComponentDataFromEntity<PhysicsVelocity> PhysicVelocityGroup;
        public ComponentDataFromEntity<HPComponentData> hpComponentGroup;

        public EntityCommandBuffer entityCommandBuffer;
        public bool ii;
        
        public void Execute(TriggerEvent triggerEvent)
        {
            
            //判断哪个是小球，然后添加向上的速度
            if (PhysicVelocityGroup.HasComponent(triggerEvent.EntityA)&& hpComponentGroup.HasComponent(triggerEvent.EntityA))
            {
                PhysicsVelocity physicsVelocity = PhysicVelocityGroup[triggerEvent.EntityA];
                physicsVelocity.Linear.y = 5f;
                PhysicVelocityGroup[triggerEvent.EntityA] = physicsVelocity;

                //UnityEngine.Debug.Log("A");
                HPComponentData hPComponentData = hpComponentGroup[triggerEvent.EntityA];
                if (hPComponentData.HP>0&&!ii)
                {
                hPComponentData.HP -= 0.5f;
                    ii = true;
                hpComponentGroup[triggerEvent.EntityA] = hPComponentData;
                }
                //entityCommandBuffer.AddComponent(triggerEvent.EntityA, new InvokTimeComponentData { DelayTime=2,StartTime= Time.ElapsedTime
                // });
                //entityCommandBuffer.SetComponent(triggerEvent.EntityA, (ref  HPComponentData hpc)=> { hpc.HP -= 1; });


                ii = false;

            }

            if (PhysicVelocityGroup.HasComponent(triggerEvent.EntityB))
            {
                PhysicsVelocity physicsVelocity = PhysicVelocityGroup[triggerEvent.EntityB];
                physicsVelocity.Linear.y = 5f;
                PhysicVelocityGroup[triggerEvent.EntityB] = physicsVelocity;
                UnityEngine.Debug.Log("B");
            }
        }
    }

    //下面讲
    private BuildPhysicsWorld buildPhysicsWorld;
    private StepPhysicsWorld stepPhysicsWorld;

    protected override void OnCreate()
    {
        buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
        stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
        beginInitializationEntityCommandBufferSystem=World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {

        //像普通Job一样进行使用，添加依赖
        TriggerJob triggerJob = new TriggerJob()
        {
            PhysicVelocityGroup = GetComponentDataFromEntity<PhysicsVelocity>(),
            hpComponentGroup = GetComponentDataFromEntity<HPComponentData>(),
            entityCommandBuffer = beginInitializationEntityCommandBufferSystem.CreateCommandBuffer()

    };
        Dependency = triggerJob.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, Dependency);

        float3 moveVal = new float3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        float deltatime = Time.DeltaTime;
        Entities.ForEach((ref PhysicsVelocity physicsVelocity, ref MoveSpeedComponent moveSpeedComponent, ref PhysicsCollider physicsCollider) => {
            if (moveSpeedComponent.MoveSpeed > 2)
            {
                return;
            }

            float3 velocityValue = physicsVelocity.Linear.xyz;
            velocityValue += moveVal * moveSpeedComponent.MoveSpeed * deltatime;
            physicsVelocity.Linear.xyz = velocityValue;

           // entityManager.AddComponentData(Entity entity, new InvokTimeComponentData { DelayTime = 2, StartTime = Time.ElapsedTime });
        }).Run();
    }

}