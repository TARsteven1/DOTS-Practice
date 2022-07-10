using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class InvokTimeComponentSystem : ComponentSystem
{
    protected override void OnUpdate()
    {


        Entities.WithAll<HPComponentData>().ForEach((Entity entity, ref HPComponentData hPComponentData) =>
        {
            if (hPComponentData.HP<1&& !hPComponentData.isDead)
            {
                hPComponentData.isDead=true;
               EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
           // Debug.Log("oo:"+Time.ElapsedTime);
            entityManager.AddComponentData( entity, new InvokTimeComponentData { DelayTime = 0.1f, StartTime = Time.ElapsedTime });

            }
        });
        
    }


}
