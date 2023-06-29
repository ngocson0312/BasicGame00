using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDEV.PlatformGame
{
    public class MainMenuCtr : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (!Pref.IsFirstTime)
            {
                GameData.Ins.LoadData();
            }else
            {
                GameData.Ins.musicVol = AudioController.ins.musicVolume;
                GameData.Ins.soundVol = AudioController.ins.sfxVolume;
                GameData.Ins.SaveData();
                LevelManager.Ins.Init();
            }

            AudioController.ins.SetMusicVolume(GameData.Ins.musicVol);
            AudioController.ins.SetSoundVolume(GameData.Ins.soundVol);

            AudioController.ins.PlayMusic(AudioController.ins.menus);

            Pref.IsFirstTime = false;
        }
    }
}
