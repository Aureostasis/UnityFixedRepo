using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip MenuTheme;
    public AudioClip Boss1Theme;
    public AudioClip Boss2Theme;

    private void Start()
    {
        musicSource.clip = MenuTheme;
        musicSource.Play();
    }

}


