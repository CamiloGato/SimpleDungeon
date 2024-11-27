using System;
using Items.Data;
using UnityEngine;

namespace Items
{
    public class Item : MonoBehaviour
    {
        public ItemData itemData;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _spriteRenderer.sprite = itemData.itemImage;
        }
    }
}