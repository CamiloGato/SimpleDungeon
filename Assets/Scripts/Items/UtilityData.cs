using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Utility", menuName = "Item/Utility", order = 0)]
    public class UtilityData : ItemData
    {
        public int utilityValue;
    }
}