using Unity.Entities;
using Unity.Mathematics;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial class CheckPlayerHealthSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities
            .WithStructuralChanges()
            .WithAll<PlayerHealthComponent>()
            .ForEach((Entity entity, ref PlayerHealthComponent health) =>
            {
                // Check if the entity has PlayerDamagedComponent
                if (EntityManager.HasComponent<PlayerDamagedComponent>(entity))
                {
                    // Reduce health & remove tag
                    health.Value = math.max(health.Value - 10, 0); // to cap at 100
                    EntityManager.RemoveComponent<PlayerDamagedComponent>(entity);
                }

                // Check if the entity has PlayerHealedComponent
                if (EntityManager.HasComponent<PlayerHealedComponent>(entity))
                {
                    // Increase health & remove tag
                    health.Value = math.min(health.Value + 10, 100); // to floor at 0
                    EntityManager.RemoveComponent<PlayerHealedComponent>(entity);
                }
            }).Run();
    }
}
