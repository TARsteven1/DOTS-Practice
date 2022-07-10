using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[GenerateAuthoringComponent]
public struct HPComponentData : IComponentData
{
    // Start is called before the first frame update
    public float HP;
    public bool isDead;
}
