using Unity.Entities;

namespace StatusEffects
{
    /// <summary>
    /// Severity for each effect 
    /// </summary>
    public struct StatusEffects : IComponentData
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
    }

    public enum StatusSeverity
    {
        None,
        Weak,
        Normal,
        High,
        Extreme,
        Godly,
    }
}