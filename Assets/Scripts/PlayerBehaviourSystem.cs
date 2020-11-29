using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Mathematics;

public class PlayerBehaviourSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation trans, ref Rotation rotate, ref PlayerComponent pc) =>
        {
            pc.rotationAngle += Input.GetAxis("Horizontal") * Time.DeltaTime;
            float3 targetDirection = new float3(math.sin(pc.rotationAngle), 0, math.cos(pc.rotationAngle));
            rotate.Value = quaternion.LookRotationSafe(targetDirection, Vector3.up);
            trans.Value += targetDirection * pc.speed * Input.GetAxis("Vertical") * Time.DeltaTime;
        });
    }
}
