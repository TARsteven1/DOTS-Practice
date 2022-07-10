using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class DeleteEntitiesSystem : ComponentSystem //JobComponentSystem
{
    protected override void OnUpdate()
    {
        double EndTime = Time.ElapsedTime;
        EntityCommandBuffer entityCommandBuffer = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

        //Entities.WithAll<DeleteTag>().ForEach((Entity entity) =>
        //{
        //    entityCommandBuffer.DestroyEntity(entity);
        //})/*.Run()*/;
        //Entities.ForEach((Entity entity2, ref HPComponentData hPComponentData) =>
        //{
        //    if (hPComponentData.HP < 1)
        //    {
        //        entityCommandBuffer.DestroyEntity(entity2);
        //    }
        //});
        Entities.ForEach((Entity entity, ref InvokTimeComponentData invokTimeComponentData) =>
        {
            //Debug.Log(EndTime - invokTimeComponentData.StartTime);
            if ((float)(EndTime - invokTimeComponentData.StartTime) >= invokTimeComponentData.DelayTime)
            {
                entityCommandBuffer.DestroyEntity(entity);
            }
        });

        entityCommandBuffer.Playback(EntityManager);
        entityCommandBuffer.Dispose();
    }
    //return default;
}
