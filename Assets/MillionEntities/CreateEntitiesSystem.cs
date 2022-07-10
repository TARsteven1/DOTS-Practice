using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;

public class CreateEntitiesSystem : ComponentSystem
{
    private EntityManager entityManager;
    int num = 100;

    protected override void OnCreate()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }
    protected override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }    
    protected override void OnStartRunning()
    {
        NativeArray<Entity> nativeArray = new NativeArray<Entity>(num* num, Allocator.Temp);
        Entities.ForEach((ref EntityPrefabManagerComponentData entityPrefabManagerComponentData) =>
        {
            entityManager.Instantiate(entityPrefabManagerComponentData.prefab, nativeArray);
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    int index = i + j * num;
                    entityManager.SetComponentData(nativeArray[index], new Translation
                    {
                        Value=new float3 (i,j,0)
                    });
                }
            }
        });
    }

    
}
