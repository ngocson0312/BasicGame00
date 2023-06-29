using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UDEV.PlatformGame
{
    public class SettingDialog : Dialog
    {
        public Slider musicSlider;
        public Slider soundSlider;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            if (musicSlider)
            {
                musicSlider.value = GameData.Ins.musicVol;
                AudioController.ins.SetMusicVolume(GameData.Ins.musicVol);
            }

            if (soundSlider)
            {
                soundSlider.value = GameData.Ins.soundVol;
                AudioController.ins.SetSoundVolume(GameData.Ins.soundVol);
            }
        }

        public void OnMusicChange(float value)
        {
            AudioController.ins.SetMusicVolume(value);
        }

        public void OnSoundChange(float value)
        {
            AudioController.ins.SetSoundVolume(value);
        }

        public void Save()
        {
            GameData.Ins.musicVol = AudioController.ins.musicVolume;
            GameData.Ins.soundVol = AudioController.ins.sfxVolume;
            GameData.Ins.SaveData();
            Close();
        }

        public override void Close()
        {
            base.Close();
            Time.timeScale = 1f;
        }
    }
}
