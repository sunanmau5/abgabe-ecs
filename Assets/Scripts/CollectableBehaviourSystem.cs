using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Burst;
using Unity.Mathematics;

public class CollectableBehaviourSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.ForEach((ref Rotation rotate, in CollectedComponent collected) =>
        {
            if (collected.isCollected)
            {
                quaternion rot = quaternion.RotateX(math.radians(collected.radiansPerSecond * deltaTime));
                rotate.Value = math.mul(rotate.Value, rot);
            }
        }).ScheduleParallel();
    }
}
