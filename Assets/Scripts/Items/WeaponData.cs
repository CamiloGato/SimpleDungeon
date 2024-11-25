using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon", order = 0)]
    public class WeaponData : ItemData
    {
        public int weaponDamage;
        public float weaponRange;
    }
}