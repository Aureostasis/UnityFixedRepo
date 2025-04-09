using System;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 3500f;
    public float spaceForce = 50f;
    private Camera mainCam;
    private int rollCD = 0;
    public GameObject player;
    public GameObject aim;
    private Rigidbody2D playerRb;
    Vector2 movement;


    // Animation variables
    public Animator animator;
    

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position).normalized;

        animator.SetFloat("SpeedX", movement.x);
        animator.SetFloat("SpeedY", movement.y);



        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rollCD <= 0) 
            { 
                Debug.Log("Pressed Spacebar");
                rb.totalForce = new Vector2(0, 0);
                rb.AddForce(direction * spaceForce, ForceMode2D.Impulse);
                rollCD = 100;
            }
        }
    }
    void FixedUpdate()
    {
        rollCD -= 1;

        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(new Vector2(0, speed * Time.deltaTime));  
        }
        if (Input.GetKey(KeyCode.S)){
            rb.AddForce(new Vector2(0, -speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A)){
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0)); 
        }
        if (Input.GetKey(KeyCode.D)){
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
        }
    }
    public void TakeDmg()
    {   
        playerRb = player.GetComponent<Rigidbody2D>();
        var blastDirection = new Vector3(0, 0, 0);
        blastDirection = (rb.linearVelocity * 5);
        blastDirection *= -1;
        Debug.Log("Touched the fireball");
        rb.AddForce(blastDirection, ForceMode2D.Impulse);
    }
}
