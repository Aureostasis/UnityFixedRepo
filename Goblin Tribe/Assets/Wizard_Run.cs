using UnityEngine;

public class Wizard_Run : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    BossMovement boss;

    public float attackRange = 3f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<BossMovement>();
        boss.canMove = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // If the player no longer exists (e.g., they died), go to Idle
        if (player == null)
        {
            boss.canMove = false;
            animator.SetTrigger("IdleTrigger");
            return;
        }

        // If player is within attack range and cooldown is done, attack
        if (Vector2.Distance(player.position, rb.position) <= attackRange &&
            Time.time >= boss.lastAttackTime + boss.attackCooldown)
        {
            animator.SetTrigger("Attack1");
            boss.lastAttackTime = Time.time;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("IdleTrigger"); 
    }
}
