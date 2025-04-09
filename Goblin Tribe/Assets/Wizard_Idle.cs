using UnityEngine;

public class Wizard_Idle : StateMachineBehaviour
{
    BossMovement boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<BossMovement>();
        if (boss != null)
        {
            boss.canMove = false;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss != null)
        {
            boss.canMove = true;
        }
    }
}
