using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct InvokTimeComponentData : IComponentData
{
   public float DelayTime;
    public double StartTime;
}
