using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
[GenerateAuthoringComponent]
public struct MoveComponentData_IS : IComponentData
{
    public float Speed;
    public float3 MoveDirection;
    public bool isJump;
}
