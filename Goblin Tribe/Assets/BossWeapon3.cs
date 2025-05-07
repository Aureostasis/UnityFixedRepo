using UnityEngine;

public class BossWeapon3 : MonoBehaviour
{
    public int attackDamage = 25;  // Unique strength for this weapon
    public Vector3 attackOffset;
    public Vector2 hitboxSize = new Vector2(1.5f, 2f); // Unique shape
    public LayerMask attackMask;
    public CubeMovement goblinScript;

    // Renamed to avoid animation event conflicts
    public void AttackWeapon3()
    {
        Vector3 pos = transform.position;

        // Flip offset based on boss facing direction
        float direction = Mathf.Sign(transform.localScale.x);
        pos += transform.right * attackOffset.x * direction;
        pos += transform.up * attackOffset.y;

        Vector2 adjustedHitboxSize = new Vector2(hitboxSize.x * direction, hitboxSize.y);

        Collider2D colInfo = Physics2D.OverlapBox(pos, hitboxSize, 0f, attackMask);

        if (colInfo != null && goblinScript.isParry == false)
        {
            PlayerHealth playerHealth = colInfo.GetComponentInParent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Boss a1 hit");
            }
            else
            {
                Debug.LogWarning("Hit object has no PlayerHealth component: " + colInfo.name);
            }
        }
        else if (colInfo != null && goblinScript.isParry == true) {
            goblinScript.parrybuttonCD = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;

        float direction = Application.isPlaying ? Mathf.Sign(transform.localScale.x) : 1f;
        pos += transform.right * attackOffset.x * direction;
        pos += transform.up * attackOffset.y;

        Vector2 adjustedHitboxSize = new Vector2(hitboxSize.x * direction, hitboxSize.y);

        Gizmos.color = Color.cyan; // Visually distinct for debugging
        Gizmos.DrawWireCube(pos, adjustedHitboxSize);
    }
}
