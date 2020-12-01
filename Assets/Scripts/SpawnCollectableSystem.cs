using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class SpawnCollectableSystem : SystemBase
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

    protected override void OnCreate()
    {
        // Cache the BeginInitializationEntityCommandBufferSystem in a field, so we don't have to create it every frame
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();
        Entities
            .WithBurst(FloatMode.Default, FloatPrecision.Standard, true)
            .ForEach((Entity entity, int entityInQueryIndex, in SpawnCollectableComponent scc) =>
            {
                Unity.Mathematics.Random rand = new Unity.Mathematics.Random(30);
                for (var x = 0; x < scc.amount; x++)
                {
                    Entity entityInstance = commandBuffer.Instantiate(entityInQueryIndex, scc.prefab);

                    // Set a random spawn position
                    float spawnPosX = rand.NextFloat(-5.0f, 5.0f);
                    float spawnPosZ = rand.NextFloat(-5.0f, 5.0f);

                    // Place the instantiated on a random position
                    float3 position = new float3(spawnPosX, -0.5f, spawnPosZ);
                    commandBuffer.SetComponent(entityInQueryIndex, entityInstance, new Translation { Value = position });
                }
                commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            }).ScheduleParallel();

        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
