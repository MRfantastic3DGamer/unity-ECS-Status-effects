using UnityEngine;

namespace Equipments
{
    public enum EquipmentType
    {
        Held,
        Wear,
    }

    public enum HeldType
    {
        Sword, Shield, Container,
    }

    public enum WearType
    {
        Ring,
        Amulet,
        Torso,
        Legs,
        Forearms,
        Shoes,
    }
    public class EquipmentAuthoring : MonoBehaviour
    {
        public EquipmentType Type;
    }
}