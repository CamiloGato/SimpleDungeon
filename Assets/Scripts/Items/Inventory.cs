using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Item/Inventory", order = 0)]
    public class Inventory : ScriptableObject
    {
        public List<Dictionary<ItemData, int>> items = new List<Dictionary<ItemData, int>>();

        public List<TItem> GetItems<TItem>() where TItem : ItemData
        {
            List<TItem> itemsOfType = new List<TItem>();
            foreach (Dictionary<ItemData, int> itemDictionary in items)
            {
                foreach (KeyValuePair<ItemData, int> item in itemDictionary)
                {
                    if (item.Key is TItem)
                    {
                        itemsOfType.Add((TItem)item.Key);
                    }
                }
            }

            return itemsOfType;
        }

        public void AddItem(ItemData itemData)
        {
            foreach (var itemDictionary in items)
            {
                if (itemDictionary.ContainsKey(itemData))
                {
                    itemDictionary[itemData]++;
                    return;
                }
            }

            items.Add(new Dictionary<ItemData, int> { { itemData, 1 } });
        }

        public void RemoveItem(ItemData itemData)
        {
            foreach (Dictionary<ItemData, int> itemDictionary in items)
            {
                if (itemDictionary.ContainsKey(itemData))
                {
                    itemDictionary[itemData]--;
                    if (itemDictionary[itemData] == 0)
                    {
                        items.Remove(itemDictionary);
                    }

                    return;
                }
            }
        }
    }
}