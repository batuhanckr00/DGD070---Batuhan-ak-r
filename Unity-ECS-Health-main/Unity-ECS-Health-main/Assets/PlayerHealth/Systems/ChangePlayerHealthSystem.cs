using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup))]
public partial class ChangePlayerHealthSystem : SystemBase
{
    protected override void OnUpdate()
    {
        // Get player input
        bool damageKeyPressed = Input.GetKeyDown(KeyCode.D);
        bool healKeyPressed = Input.GetKeyDown(KeyCode.H);

        if (damageKeyPressed || healKeyPressed)
        {
            Entities
                .WithStructuralChanges()
                .WithAll<PlayerHealthComponent>()
                .ForEach((Entity entity) =>
                {
                    if (damageKeyPressed && !EntityManager.HasComponent<PlayerDamagedComponent>(entity))
                    {
                        // Place a PlayerDamaged component on all entities
                        EntityManager.AddComponent<PlayerDamagedComponent>(entity); 
                        Debug.Log("Player damaged");
                    }

                    if (healKeyPressed && !EntityManager.HasComponent<PlayerHealedComponent>(entity))
                    {
                        // Place a PlayerHealed component on all entities
                        EntityManager.AddComponent<PlayerHealedComponent>(entity);
                        Debug.Log("Player healed");
                    }
                }).Run();
        }
    }
}
