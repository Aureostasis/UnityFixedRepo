using UnityEngine;
using UnityEngine.Events;

public class fireSpellTrigger : MonoBehaviour
{
    public GameObject fireball;
    public UnityEvent fireballDmg;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
           
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touched the fireball");
        fireballDmg.Invoke();
    }
}
