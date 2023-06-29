using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDEV.PlatformGame
{
    public class LevelItemUI : MonoBehaviour
    {
        public Image preview;
        public GameObject lockedArea;
        public GameObject checkMark;
        public Text priceTxt;
        public Button btnComp;

        public void UpdateUI(LevelItem levelItem, int levelIdx)
        {
            if (levelItem == null) return;

            bool isUnlocked = GameData.Ins.IsLevelUnlocked(levelIdx);

            if (preview)
            {
                preview.sprite = levelItem.preview;
            }

            if (priceTxt)
            {
                priceTxt.text = levelItem.price.ToString();
            }

            if (lockedArea)
            {
                lockedArea.SetActive(!isUnlocked);
            }

            if (isUnlocked)
            {
                if (checkMark)
                {
                    checkMark.SetActive(GameData.Ins.curLevelId == levelIdx);
                }
            }else if (checkMark)
            {
                checkMark.SetActive(false);
            }
        }
    }
}
