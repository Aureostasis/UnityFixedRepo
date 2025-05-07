using UnityEngine;

public class parry : MonoBehaviour
{
    public Animator animator;
    public GameObject GameObject;
    private int parryCD = 0;

    private void FixedUpdate()
    {
        parryCD -= 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Pressed Parry(Q)");
            if (parryCD <= 0)
            {
                animator.SetTrigger("startParry");
                Debug.Log("Parry Stance Triggered");
                parryCD = 100;
            }
        }
    }
}
