using Unity.Entities;

[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial class CreatePlayerHealthSystem : SystemBase
{
    protected override void OnCreate()
    {
        var entity = EntityManager.CreateEntity();
        EntityManager.AddComponentData(entity, new PlayerHealthComponent { Value = 100 });
    }

    protected override void OnUpdate() { }
}