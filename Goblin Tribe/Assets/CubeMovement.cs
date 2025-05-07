using System;
using UnityEngine;
using UnityEngine.Events;

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
    public GameObject parry;
    public int parryCD = 0;
    public int parrybuttonCD = 0;
    public bool isParry;
    UnityEvent giveInvuln;



    // Animation variables
    public Animator animator;
    

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (giveInvuln == null)
            giveInvuln = new UnityEvent();
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

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (parrybuttonCD <= 0)
            {
                animator.SetTrigger("startParry");
                animator.SetBool("isParrying", true);
                isParry = true;
                parry.SetActive(true);
                Debug.Log("Parry Pressed");
                parryCD = 50;
                parrybuttonCD = 50;


            }
        }
    }
    void FixedUpdate()
    {
        if (rollCD > 0) { 
            rollCD -= 1; 
        }
        if (parrybuttonCD > 0)
        {
            parrybuttonCD -= 1;
        }
        if (parryCD > 0) {
            parryCD -= 1;
            if (parryCD == 38)
            {
                isParry = false;
                parry.SetActive(false);
                animator.SetBool("isParrying", false);

            }
        }
        

        Vector2 force = Vector2.zero;

        if (Input.GetKey(KeyCode.W) && isParry == false)
        {
            force += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S) && isParry == false)
        {
            force += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A) && isParry == false)
        {
            force += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D) && isParry == false)
        {
            force += Vector2.right;
        }

        // Normalize the force vector if its magnitude is greater than 1
        if (force.magnitude > 1)
        {
            force = force.normalized;
        }

        rb.AddForce(force * speed * Time.deltaTime);

        
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
