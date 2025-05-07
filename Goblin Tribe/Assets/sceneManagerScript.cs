using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManagerScript : MonoBehaviour
{
    public static sceneManagerScript Instance;
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
    public void LoadSceneByIndex(int indx)
    {
        SceneManager.LoadSceneAsync(indx);
    }

    public void QuitGame() { 
        Application.Quit();
    }
}
