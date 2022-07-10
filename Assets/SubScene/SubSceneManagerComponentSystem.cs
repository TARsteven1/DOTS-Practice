using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Scenes;
using Unity.Transforms;
using Unity.Mathematics;

public class SubSceneManagerComponentSystem : ComponentSystem
{
   private SceneSystem subScene;
    protected override void OnCreate()
    {
        subScene=World.GetOrCreateSystem<SceneSystem>();
    }
    protected override void OnUpdate()
    {
        Entities.WithAll<PlayerTag>().ForEach((ref Translation translation,ref  PlayerTag playerTag) => {
            float3 Player_Pos = translation.Value;
            float tempview = playerTag.View;
            Entities.ForEach(( SubSceneManagerComponentData  subSceneManagerComponentData)=> {
                for (int i = 0; i < subSceneManagerComponentData.SubScenes.Length; i++)
                {
                    float3 SubScene_Pos = subSceneManagerComponentData.SubScenes[i].transform.position;
                    if (math.distance(Player_Pos, SubScene_Pos)< tempview)
                    {
                        subScene.LoadSceneAsync(subSceneManagerComponentData.SubScenes[i].SceneGUID);
                        //Debug.Log(SubScene_Pos);
                    }
                    else
                    {
                        subScene.UnloadScene(subSceneManagerComponentData.SubScenes[i].SceneGUID);
                    }
                }
            });
        
        });
    }

   
}
