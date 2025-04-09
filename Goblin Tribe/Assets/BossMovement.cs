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

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
