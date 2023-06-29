using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDEV.PlatformGame
{
    public class ShopItemUI : MonoBehaviour
    {
        public Text priceTxt;
        public Text amountTxt;
        public Image preview;
        public Button btnComp;

        public void UpdateUI(ShopItem shopItem, int itemIdx)
        {
            if (shopItem == null) return;

            if (preview)
            {
                preview.sprite = shopItem.preview;
            }

            switch (shopItem.itemType)
            {
                case CollectableType.Hp:
                    UpdateAmountTxt(GameData.Ins.hp);
                    break;
                case CollectableType.Live:
                    UpdateAmountTxt(GameData.Ins.live);
                    break;
                case CollectableType.Bullet:
                    UpdateAmountTxt(GameData.Ins.bullet);
                    break;
                case CollectableType.Key:
                    UpdateAmountTxt(GameData.Ins.key);
                    break;
            }

            if(priceTxt)
            {
                priceTxt.text = shopItem.price.ToString();
            }
        }

        private void UpdateAmountTxt(int amount)
        {
            if (amountTxt)
            {
                amountTxt.text = amount.ToString();
            }
        }
    }
}
