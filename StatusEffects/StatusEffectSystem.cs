using Unity.Entities;

namespace StatusEffects
{
    public partial struct StatusEffectSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate(SystemAPI.QueryBuilder().WithAll<StatusEffects, Health.Health>().Build());
        }
        
        public void OnUpdate(ref SystemState state)
        {
            
        }
    }

    public readonly partial struct StatusUserAspect : IAspect
    {
        public readonly RefRO<StatusEffects> StatusEffects;
        public readonly RefRW<Health.Health> Health;
    }
}