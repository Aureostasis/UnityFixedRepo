using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip MenuTheme;
    public AudioClip Boss1Theme;
    public AudioClip Boss2Theme;

    public static AudioManager Instance;

    private void Start()
    {
        changeAudioTrack();
    }

    private void Awake()
    {
        // If there is no instance or this is the first instance, set it
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object between scene changes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates if the instance already exists
        }
    }

    public void changeAudioTrack()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");

        if (scene.name == "Main Menu")
        {
            musicSource.clip = MenuTheme;
            musicSource.Play();
        }
        if (scene.name == "Boss 1")
        {
            musicSource.clip = Boss1Theme;
            musicSource.Play();
        }
        if (scene.name == "Boss 2")
        {
            musicSource.clip = Boss2Theme;
            musicSource.Play();
        }
    }

}


