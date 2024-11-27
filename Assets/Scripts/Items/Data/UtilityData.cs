using UnityEngine;

namespace Items.Data
{
    [CreateAssetMenu(fileName = "Utility", menuName = "Item/Utility", order = 0)]
    public class UtilityData : ItemData
    {
        public int utilityValue;
    }
}