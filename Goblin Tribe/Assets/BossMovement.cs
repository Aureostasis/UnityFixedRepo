using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform Player;
    public float moveSpeed = 5f;
    public Animator animator;

    public int maxHealth = 100;
    private int currentHealth;

    public float attackCooldown = 2f;
    public float lastAttackTime = -999f;

    public bool canMove = true;
    private bool isDead = false;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Player == null || !canMove) return;

        Vector3 direction = Player.position - transform.position;
        direction.Normalize();
        movement = direction;

        if (movement.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (movement.x > 0)
            transform.localScale = new Vector3(1, 1, 1);

        animator.SetFloat("Speed", Mathf.Abs(movement.x) * moveSpeed);
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (damage >= 10)
        {
            animator.SetTrigger("TakeHit");
            Debug.Log("TakeHit triggered");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("Death");
        canMove = false;

        // Lower sprite render order to be behind the player
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            sr.sortingOrder -= 1;
        }

        // Disable all colliders
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D col in colliders)
        {
            col.enabled = false;
        }

        // Freeze physics
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
        }

        this.enabled = false;
    }


}
