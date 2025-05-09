using UnityEngine;

public class changeBossMusic : MonoBehaviour
{
    private AudioManager audioManager;
    private GameObject audioObject;
    void Start()
    {
        audioObject = GameObject.FindGameObjectWithTag("Audio");
        audioManager = audioObject.GetComponent<AudioManager>();
        audioManager.changeAudioTrack();
    }
}
