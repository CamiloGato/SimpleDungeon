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

        private List<ItemView> _items = new List<ItemView>();

        private void Start()
        {
            foreach (Transform child in inventoryPanel)
            {
                Destroy(child.gameObject);
            }
        }

        private void OnEnable()
        {
            inventory.OnItemAdded += OnItemAdded;
            inventory.OnItemRemoved += OnItemRemoved;
        }

        private void OnDisable()
        {
            inventory.OnItemAdded -= OnItemAdded;
            inventory.OnItemRemoved -= OnItemRemoved;
        }

        private void OnItemAdded(ItemData itemData, int amount)
        {
            if (amount > 1)
            {
                ItemView item = _items.Find(element => element.ItemName == itemData.itemName);
                item.UpdateAmount(amount);
                return;
            }

            ItemView newItem = Instantiate(itemView, inventoryPanel);
            newItem.SetUpItem(itemData.itemImage, itemData.itemName);
            _items.Add(newItem);
        }

        private void OnItemRemoved(ItemData item, int amount)
        {
            ItemView itemToRemove = _items.Find(element => element.ItemName == item.itemName);
            if (amount <= 0)
            {
                _items.Remove(itemToRemove);
                Destroy(itemToRemove.gameObject);
            }
            else
            {
                itemToRemove.UpdateAmount(amount);
            }
        }
    }
}