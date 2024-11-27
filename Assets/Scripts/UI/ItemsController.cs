using System.Collections.Generic;
using Items;
using UnityEngine;

namespace UI
{
    public class ItemsController : MonoBehaviour
    {
        public ItemView itemView;
        public Inventory inventory;
        public Transform inventoryPanel;

        private Dictionary<ItemData ,ItemView> _items = new Dictionary<ItemData, ItemView>();

        public void Initialize()
        {
            foreach (Transform child in inventoryPanel)
            {
                Destroy(child.gameObject);
            }
        }

        public void AddSubscriptions()
        {
            inventory.OnItemAdded += OnItemAdded;
            inventory.OnItemRemoved += OnItemRemoved;
        }

        public void RemoveSubscription()
        {
            inventory.OnItemAdded -= OnItemAdded;
            inventory.OnItemRemoved -= OnItemRemoved;
        }

        private void OnItemAdded(ItemData itemData, int amount)
        {
            if (amount > 1)
            {
                _items.TryGetValue(itemData, out ItemView item);
                item?.UpdateAmount(amount);
                return;
            }

            ItemView newItem = Instantiate(itemView, inventoryPanel);
            newItem.SetUpItem(itemData.itemImage, itemData.itemName);
            _items.Add(itemData ,newItem);
        }

        private void OnItemRemoved(ItemData itemData, int amount)
        {
            _items.TryGetValue(itemData, out ItemView itemToRemove);
            if (amount <= 0)
            {
                _items.Remove(itemData);
                Destroy(itemToRemove?.gameObject);
            }
            else
            {
                itemToRemove?.UpdateAmount(amount);
            }
        }
    }
}