using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private TMP_Text itemNameTmp;
        [SerializeField] private TMP_Text itemAmountTmp;

        public string ItemName => itemNameTmp.text;

        public void SetUpItem(Sprite itemSprite, string itemName)
        {
            itemImage.sprite = itemSprite;
            itemNameTmp.text = itemName;
            itemAmountTmp.text = "1";
        }

        public void UpdateAmount(int amount)
        {
            itemAmountTmp.text = amount.ToString();
        }

    }
}