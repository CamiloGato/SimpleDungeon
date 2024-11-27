using System;
using System.Collections.Generic;
using Items.Data;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Item/Inventory", order = 0)]
    public class Inventory : ScriptableObject
    {
        public Action<ItemData, int> OnItemAdded;
        public Action<ItemData, int> OnItemRemoved;

        public Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();

        public List<TItem> GetItems<TItem>() where TItem : ItemData
        {
            List<TItem> itemsOfType = new List<TItem>();
            foreach (KeyValuePair<ItemData, int> itemDictionary in items)
            {
                if (itemDictionary.Key is TItem item)
                {
                    itemsOfType.Add(item);
                }
            }

            return itemsOfType;
        }

        public void AddItem(ItemData itemData)
        {
            if (!items.TryAdd(itemData, 1))
            {
                items[itemData]++;
            }

            OnItemAdded?.Invoke(itemData, items[itemData]);
        }

        public void RemoveItem(ItemData itemData)
        {
            if (items.TryGetValue(itemData, out int amount))
            {
                if (amount > 1)
                {
                    items[itemData]--;
                }
                else
                {
                    items.Remove(itemData);
                }

                OnItemRemoved?.Invoke(itemData, amount - 1);
            }
        }
    }
}