using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public int attackDamage = 20;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;

        // Flip offset if boss is flipped (scale.x < 0)
        float direction = Mathf.Sign(transform.localScale.x);
        pos += transform.right * attackOffset.x * direction;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        if (colInfo != null)
        {
            PlayerHealth playerHealth = colInfo.GetComponentInParent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
            else
            {
                Debug.LogWarning("Hit object has no PlayerHealth component: " + colInfo.name);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;

        // Match visualization with runtime logic
        float direction = Application.isPlaying ? Mathf.Sign(transform.localScale.x) : 1f;
        pos += transform.right * attackOffset.x * direction;
        pos += transform.up * attackOffset.y;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
