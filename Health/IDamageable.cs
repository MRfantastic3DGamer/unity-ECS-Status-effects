using StatusEffects;
using Unity.Entities;

namespace Health
{
    public struct Health : IComponentData
    {
        public float CurrentHealth;
        public float MaxHealth;
    }

    public struct ThisFrameStatusEffect : IComponentData
    {
        public StatusSeverity 
            Burned,
            Shocked,
            Poisoned,
            Frozen,
            Electrified,
            Stoned,
            Floaty,
            Weakened;

        public float HealthModification;
    }
}