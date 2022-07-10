using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Scenes;
[GenerateAuthoringComponent]
public class SubSceneManagerComponentData : IComponentData
{
    public SubScene[] SubScenes;
}
