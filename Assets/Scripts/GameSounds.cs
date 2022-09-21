using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameSounds : MonoBehaviour
{
    public GameObject panel;
    public GameObject openSoundsButton;

    public GameObject masterButton;
    public GameObject backgroundButton;
    public GameObject soundButton;

    public Sprite mute;
    public Sprite unmute;

    public AudioSource ploopSound;
    public AudioSource catArriveSound;
    public AudioSource catUpgradeSound;
    public AudioSource roomBuiltSound;
    public AudioSource roomUpgradeSound;
    public AudioSource collectMoneySound;

    bool masterIsMute = false;
    float prevMasterVolume;
    bool backgroundIsMute = false;
    float prevBackgroundVolume; 
    bool soundIsMute = false;
    float prevSoundVolume;

    public AudioMixer mixer;

    public void Start()
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(0.5f) * 20);
        mixer.SetFloat("BackgroundVolume", Mathf.Log10(0.5f) * 20);
        mixer.SetFloat("SoundVolume", Mathf.Log10(0.5f) * 20);
    }

    public void playRoomBuiltSound() 
    {
        roomBuiltSound.Play();
    }

    public void playRoomUpgradeSound() 
    {
        roomUpgradeSound.Play();
    }

    public void playCatArriveSound() 
    {
        catArriveSound.Play();
    }

    public void playCatUpgradeSound() 
    {
        catUpgradeSound.Play();
    }

    public void playCollectMoneySound() 
    {
        collectMoneySound.Play();
    }

    public void playPloopSound() 
    {
        ploopSound.Play();
    }

    public void SetLevelMaster(float sliderValue) 
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelBackground(float sliderValue) 
    {
        mixer.SetFloat("BackgroundVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelSound(float sliderValue) 
    {
        mixer.SetFloat("SoundVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void showPanel() 
    {
        panel.SetActive(true);
    }

    public void hidePanel() 
    {
        panel.SetActive(false);
    }

    public void togglePanel() 
    {
        if (panel.activeSelf) {
            hidePanel();
        } else {
            showPanel();
        }
    }

    public void muteMaster() 
    {
        if (!masterIsMute) {
            masterIsMute = true;
            mixer.GetFloat("MasterVolume", out prevMasterVolume);
            mixer.SetFloat("MasterVolume", Mathf.Log10(0.00001f) * 20);
            masterButton.GetComponent<Image>().sprite = mute;
        } else {
            masterIsMute = false;
            mixer.SetFloat("MasterVolume", Mathf.Log10(0.5f) * 20);
            masterButton.GetComponent<Image>().sprite = unmute;
        }
    }

    public void muteBackground() 
    {
        if (!backgroundIsMute) {
            backgroundIsMute = true;
            mixer.GetFloat("BackgroundVolume", out prevBackgroundVolume);
            mixer.SetFloat("BackgroundVolume", Mathf.Log10(0.00001f) * 20);
            backgroundButton.GetComponent<Image>().sprite = mute;
        } else {
            backgroundIsMute = false;
            mixer.SetFloat("BackgroundVolume", Mathf.Log10(0.5f) * 20);
            backgroundButton.GetComponent<Image>().sprite = unmute;
        }
    }

    public void muteSound() 
    {
        if (!soundIsMute) {
            soundIsMute = true;
            mixer.GetFloat("SoundVolume", out prevSoundVolume);
            mixer.SetFloat("SoundVolume", Mathf.Log10(0.00001f) * 20);
            soundButton.GetComponent<Image>().sprite = mute;
        } else {
            soundIsMute = false;
            mixer.SetFloat("SoundVolume", Mathf.Log10(0.5f) * 20);
            soundButton.GetComponent<Image>().sprite = unmute;
        }
    }
}
