using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDEV.PlatformGame
{
    public class LevelFailedDialog : Dialog
    {
        public Text timeCountingTxt;
        public Text coinCountingTxt;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            if (timeCountingTxt)
            {
                timeCountingTxt.text = $"{Helper.TimeConvert(GameManager.Ins.GameplayTime)}";
            }

            if(coinCountingTxt)
            {
                coinCountingTxt.text = $"{GameManager.Ins.CurCoin}";
            }
        }

        public void Replay()
        {
            Close();
            GameManager.Ins.Replay();
        }

        public void BackToMenu()
        {
            SceneController.Ins.LoadScene(GameScene.MainMenu.ToString());
        }
    }
}
