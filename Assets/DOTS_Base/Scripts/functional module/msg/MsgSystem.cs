using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class MsgSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        //Entities.ForEach<string>((ref MsgComponent msgComponent) => {
           // msgComponent.msg = "hhhhh";
           // Debug.Log(msgComponent.Level);
       // });
    }
}
