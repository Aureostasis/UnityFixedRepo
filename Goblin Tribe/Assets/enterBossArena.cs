using UnityEngine;
using UnityEngine.UI;


public class enterBossArena : MonoBehaviour
{
    public Button yourButton;
    void Start()
    {
        yourButton.onClick.AddListener(() => sceneManagerScript.Instance.LoadSceneByIndex(1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
