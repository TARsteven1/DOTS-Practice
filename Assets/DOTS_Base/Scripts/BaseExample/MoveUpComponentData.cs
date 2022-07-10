using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[GenerateAuthoringComponent]
public struct MoveUpComponentData : IComponentData
{
    public float MoveSpeed2;
    public float offsetX;
    public float offsetY;
    public float Pow;

}
