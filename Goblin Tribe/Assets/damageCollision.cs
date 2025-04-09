using UnityEngine;

public class damageCollision : MonoBehaviour
{
    public int attackDamage = 50;
    public GameObject bossBody;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BossMovement bossScript = collision.GetComponent<BossMovement>();

        bossBody = GameObject.FindGameObjectWithTag("Boss");


        if (collision.gameObject.tag == "Boss")
        {
            bossScript.TakeDamage(attackDamage);
            Debug.Log("Boss hit! Dealt " + attackDamage + " damage.");
        }
    }
}
