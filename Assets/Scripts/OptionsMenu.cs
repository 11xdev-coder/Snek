using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer mainAudioMixer;
    public AudioMixer gameSoundtrackAudioMixer;
    public AudioMixer soundEffectsAudioMixer;

    public TMP_Dropdown resolutionsDropdown;

    private Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolumeMainMenu(float volume)
    {
        mainAudioMixer.SetFloat("mainmenuvolume", volume);
    }

    public void SetVolumeGameSoundtrack(float volume)
    {
        gameSoundtrackAudioMixer.SetFloat("GameSoundtrackVolume", volume);
    }

    public void SetVolumeSoundEffects(float volume)
    {
        soundEffectsAudioMixer.SetFloat("SoundEffectsVolume", volume);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
