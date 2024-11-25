using UnityEngine;

namespace Items
{
    public abstract class ItemData : ScriptableObject
    {
        public Sprite itemImage;
        public string itemName;
        public string itemDescription;
    }
}