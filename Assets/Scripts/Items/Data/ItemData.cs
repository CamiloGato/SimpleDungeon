using UnityEngine;

namespace Items.Data
{
    public abstract class ItemData : ScriptableObject
    {
        public Sprite itemImage;
        public string itemName;
        public string itemDescription;
    }
}