using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDEV.PlatformGame
{
    public class LevelSelectDialog : Dialog
    {
        public Transform gridRoot;
        public LevelItemUI itemUIPb;
        public Text coinCountingTxt;

        public override void Show(bool isShow)
        {
            base.Show(isShow);
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (coinCountingTxt)
            {
                coinCountingTxt.text = GameData.Ins.coin.ToString();
            }

            var levels = LevelManager.Ins.levels;

            if (levels == null || !gridRoot || !itemUIPb) return;

            Helper.ClearChilds(gridRoot);

            for (int i = 0; i < levels.Length; i++)
            {
                int levelIdx = i;
                var level = levels[levelIdx];
                if (level == null) continue;

                var itemUIClone = Instantiate(itemUIPb, Vector3.zero, Quaternion.identity);
                itemUIClone.transform.SetParent(gridRoot);
                itemUIClone.transform.localScale = Vector3.one;
                itemUIClone.transform.localPosition = Vector3.zero;
                itemUIClone.UpdateUI(level, levelIdx);
                if (itemUIClone.btnComp)
                {
                    itemUIClone.btnComp.onClick.RemoveAllListeners();
                    itemUIClone.btnComp.onClick.AddListener(() => ItemEvent(level, levelIdx));
                }
            }
        }

        private void ItemEvent(LevelItem levelItem, int levelIdx)
        {
            if (levelItem == null) return;

            bool isUnlocked = GameData.Ins.IsLevelUnlocked(levelIdx);

            if (isUnlocked)
            {
                GameData.Ins.curLevelId = levelIdx;
                GameData.Ins.SaveData();

                LevelManager.Ins.CurLevelId = levelIdx;

                UpdateUI();

                SceneController.Ins.LoadLevelScene(levelIdx);
            }
            else
            {
                if(GameData.Ins.coin >= levelItem.price)
                {
                    GameData.Ins.coin -= levelItem.price;
                    GameData.Ins.curLevelId = levelIdx;
                    GameData.Ins.UpdateLevelUnlocked(levelIdx, true);
                    GameData.Ins.SaveData();

                    LevelManager.Ins.CurLevelId = levelIdx;

                    UpdateUI();

                    SceneController.Ins.LoadLevelScene(levelIdx);

                    AudioController.ins.PlaySound(AudioController.ins.unlock);
                }
                else
                {
                    Debug.Log("You don't have enough coins!!!");
                }
            }
        }
    }
}
