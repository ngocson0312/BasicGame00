using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.PlatformGame
{
    public class LevelManager : Singleton<LevelManager>
    {
        public LevelItem[] levels;
        private int m_curLevelId;

        public int CurLevelId { get => m_curLevelId; set => m_curLevelId = value; }

        public LevelItem CurLevel
        {
            get => levels[m_curLevelId];// curLevelId = 2 chung se lay LevelItem thu 2 o trong mang levels
        }

        public void Init()
        {
            if (levels == null || levels.Length <= 0) return;

            for (int i = 0; i < levels.Length; i++)
            {
                var level = levels[i];

                if(level != null)
                {
                    if (i == 0)
                    {
                        GameData.Ins.UpdateLevelUnlocked(i, true);
                        GameData.Ins.curLevelId = i;
                    }else
                    {
                        GameData.Ins.UpdateLevelUnlocked(i, false);
                    }

                    GameData.Ins.UpdateLevelPassed(i, false);
                    GameData.Ins.UpdatePlayTime(i, 0f);
                    GameData.Ins.UpdateCheckPoint(i, Vector3.zero);
                    GameData.Ins.UpdateLevelScoreNoneCheck(i, 0);
                    GameData.Ins.SaveData();
                }
            }
        }
    }
}
