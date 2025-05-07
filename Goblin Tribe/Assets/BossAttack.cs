using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 20;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
    public CubeMovement goblinScript;

    public void Attack2()
    {
        Vector3 pos = transform.position;

        // Flip offset if boss is flipped (scale.x < 0)
        float direction = Mathf.Sign(transform.localScale.x);
        pos += transform.right * attackOffset.x * direction;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        if (colInfo != null && goblinScript.isParry == false)
        {
            PlayerHealth playerHealth = colInfo.GetComponentInParent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Boss a3 hit");
            }
            else
            {
                Debug.LogWarning("Hit object has no PlayerHealth component: " + colInfo.name);
            }
        }
        else if (colInfo != null && goblinScript.isParry == true)
        {
            goblinScript.parrybuttonCD = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;

        float direction = Application.isPlaying ? Mathf.Sign(transform.localScale.x) : 1f;
        pos += transform.right * attackOffset.x * direction;
        pos += transform.up * attackOffset.y;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
