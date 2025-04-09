using UnityEngine;

public class fireballMovement : MonoBehaviour
{
    public float ballSpeed = 7f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(ballSpeed * Time.deltaTime, 0);
        
        if (transform.position.x >= 13 ) {
            ballSpeed *= -1;
        }

        if (transform.position.x <= -13 ){
            ballSpeed *= -1;
        }
    }
}
