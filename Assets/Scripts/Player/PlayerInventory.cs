using System;
using System.Collections.Generic;
using Items;
using UnityEngine;

namespace Player
{
    public class PlayerInventory : MonoBehaviour
    {
        private PlayerVariables _playerVariables;

        private Inventory Inventory => _playerVariables.playerInventory;
        private List<WeaponData> Weapons => Inventory.GetItems<WeaponData>();
        private List<UtilityData> Utilities => Inventory.GetItems<UtilityData>();

        private int _currentWeapon;
        private int _currentUtility;

        public void Initialize()
        {
            CollectItem(_playerVariables.defaultWeapon);
            ChangeWeapon();
        }

        private void Awake()
        {
            _playerVariables = GetComponent<PlayerVariables>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangeWeapon();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeUtility();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Item item))
            {
                CollectItem(item.itemData);
                Destroy(other.gameObject);
            }
        }

        private void ChangeWeapon()
        {
            _currentWeapon++;
            if (_currentWeapon >= Weapons.Count)
            {
                _currentWeapon = 0;
            }
            _playerVariables.weaponData = Weapons[_currentWeapon];
        }

        private void ChangeUtility()
        {
            _currentUtility++;
            if (_currentUtility >= Utilities.Count)
            {
                _currentUtility = 0;
            }
            _playerVariables.utilityData = Utilities[_currentUtility];
        }

        private void CollectItem(ItemData itemData)
        {
            Inventory.AddItem(itemData);
        }

    }
}