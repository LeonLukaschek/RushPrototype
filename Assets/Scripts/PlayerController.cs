using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health;

    public float speed;
    public float jumpHeight;

    public bool isResetting;

    private float timeBetweenJumps;
    private float nextJumpTime = 0;

    private bool isGrounded;
    private bool canDoubleJump;

    private Rigidbody2D rb;
    private RaycastHit2D hit;

    private void Start()

    {
        rb = GetComponent<Rigidbody2D>();

        isResetting = false;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y > 0.05f || rb.velocity.y < -0.05f)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }

        if (!isResetting)
        {
            Vector2 movement = new Vector3(Input.GetAxis("Horizontal") * speed, 0);

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

            this.transform.position += new Vector3(movement.x, movement.y, 0) * Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);

            canDoubleJump = true;
        }
        else
        {
            if (canDoubleJump)
            {
                canDoubleJump = false;

                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
        }
    }
}