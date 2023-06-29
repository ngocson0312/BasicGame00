using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDEV.PlatformGame {
    public class LevelClearedDialog : Dialog
    {
        public Image[] stars;
        public Sprite activeStar;
        public Sprite deactiveStar;

        public Text liveCountingTxt;
        public Text hpCountingText;
        public Text timeCountingTxt;
        public Text coinCountingTxt;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            if(stars != null && stars.Length > 0)
            {
                for (int i = 0; i < stars.Length; i++)
                {
                    var star = stars[i];
                    if (star)
                    {
                        star.sprite = deactiveStar;
                    }
                }

                for (int i = 0; i < GameManager.Ins.GoalStar; i++)
                {
                    var star = stars[i];
                    if (star)
                    {
                        star.sprite = activeStar;
                    }
                }
            }

            if (liveCountingTxt)
            {
                liveCountingTxt.text = $"x {GameManager.Ins.CurLive}";
            }

            if (hpCountingText)
            {
                hpCountingText.text = $"x {GameManager.Ins.player.CurHp}";
            }

            if (timeCountingTxt)
            {
                timeCountingTxt.text = $"x {Helper.TimeConvert(GameManager.Ins.GameplayTime)}";
            }

            if (coinCountingTxt)
            {
                coinCountingTxt.text = $"x {GameManager.Ins.CurCoin}";
            }
        }

        public void Replay()
        {
            Close();
            GameManager.Ins.Replay();
        }

        public void NextLevel()
        {
            Close();
            GameManager.Ins.NextLevel();
        }
    }
}
