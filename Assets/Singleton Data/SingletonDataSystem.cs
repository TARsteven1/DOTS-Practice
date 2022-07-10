using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SingletonDataSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireSingletonForUpdate<TestSingletonComponentData>();
        EntityManager.CreateEntity(typeof(TestSingletonComponentData));
    }    
    protected override void OnUpdate()
    {
        
    }

}
