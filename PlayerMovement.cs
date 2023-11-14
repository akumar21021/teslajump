using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpPower;

    Vector3 moveDirection;
    bool isFacingRight;
    float horizontal;
    float vertical;
    Rigidbody2D rb;
    bool hasCollidedWithBarrier = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

        Flip();
        TeleportOtherSide();

    }

    private void FixedUpdate()

    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;
        //print(horizontal);

        transform.Translate(moveDirection);


    }

    private void Flip()

    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {

            if (hasCollidedWithBarrier)
            {
                Jump(); // Call jump function if already collided with the barrier
            }
            else
            {
                hasCollidedWithBarrier = true; // Set flag to true on first collision
            }
        }
            if (collision.gameObject.tag == "StartFloor")
            {


                Jump(); // Call jump function if already collided with the barrier


            }


        
    }
        void Jump()
        {
            rb.velocity = new Vector2(0, jumpPower); // Apply the jump force to the Rigidbody's Y axis velocity
            Debug.Log(rb.velocity.y);
        }

        private void TeleportOtherSide()
        {
            if (transform.position.x > 10)
            {
                transform.position = new Vector3(-10.0f, transform.position.y);
            }
            else if (transform.position.x < -10.0f)
            {
                transform.position = new Vector3(10.0f, transform.position.y);
            }
        }
    } 



