using UnityEngine;

public class Wizard_Attack : StateMachineBehaviour
{
    private BossMovement boss;
    private Rigidbody2D rb;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<BossMovement>();
        rb = animator.GetComponent<Rigidbody2D>();

        if (boss != null)
        {
            boss.canMove = false;
        }

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero; // Stop any movement
            rb.bodyType = RigidbodyType2D.Kinematic; // Prevent being pushed
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss != null)
        {
            boss.canMove = true;
        }

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Restore normal physics
        }
    }
}
