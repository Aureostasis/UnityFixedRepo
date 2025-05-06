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
        if (player == null)
        {
            boss.canMove = false;
            animator.SetTrigger("IdleTrigger");
            return;
        }

        // Check distance and attack if in range and cooldown allows
        if (Vector2.Distance(player.position, rb.position) <= attackRange &&
            Time.time >= boss.lastAttackTime + boss.attackCooldown)
        {
            animator.SetTrigger("Attack1");
            boss.lastAttackTime = Time.time;
        }

        // No damage or TakeHit logic here anymore
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Only reset triggers that this state sets. Do NOT reset TakeHit
        animator.ResetTrigger("Attack1");
        animator.ResetTrigger("IdleTrigger");

        // ?? DO NOT include: animator.ResetTrigger("TakeHit");
    }
}
