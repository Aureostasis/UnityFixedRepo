using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume) {
        audioMixer.SetFloat("Volume", volume);    
    }

    public void SetFullscreen(bool isFullscreen) { 
        Screen.fullScreen = isFullscreen;
    }

    private void Start()
    {
        audioMixer.SetFloat("Volume", -30f);
    }
}
