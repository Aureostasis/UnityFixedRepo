using UnityEngine;

public class BossWeapon2 : MonoBehaviour
{
    public int attackDamage = 20;
    public Vector3 attackOffset;
    public Vector2 hitboxSize = new Vector2(2f, 1f); // Width and height of the attack area
    public LayerMask attackMask;
    public CubeMovement goblinScript;

    public void Attack()
    {
        Vector3 pos = transform.position;

        // Flip offset if boss is flipped (scale.x < 0)
        float direction = Mathf.Sign(transform.localScale.x);
        pos += transform.right * attackOffset.x * direction;
        pos += transform.up * attackOffset.y;

        // Flip hitbox horizontally if needed
        Vector2 adjustedHitboxSize = new Vector2(hitboxSize.x * direction, hitboxSize.y);

        Collider2D colInfo = Physics2D.OverlapBox(pos, hitboxSize, 0f, attackMask);

        if (colInfo != null && goblinScript.isParry == false)
        {
            PlayerHealth playerHealth = colInfo.GetComponentInParent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Boss a2 hit");
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

        Vector2 adjustedHitboxSize = new Vector2(hitboxSize.x * direction, hitboxSize.y);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(pos, adjustedHitboxSize);
    }
}
