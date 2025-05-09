using UnityEngine;
using UnityEngine.SceneManagement;

public class bossDefeatButton : MonoBehaviour
{
    public GameObject sManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void boss1DefeatedButton() {
        sManager = GameObject.FindGameObjectWithTag("SceneManager");
        sceneManagerScript sn = sManager.GetComponent<sceneManagerScript>();
        sn.LoadSceneByIndex(2);
    }
}
