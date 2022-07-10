using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[GenerateAuthoringComponent]

public struct PlayerTag : IComponentData
{
    public float Speed;
    public float View;
}
