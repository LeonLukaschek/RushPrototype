using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpHeight;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movement = new Vector3(Input.GetAxis("Horizontal") * speed, 0);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            //rb.velocity = new Vector3(0, jumpHeight * Time.deltaTime, 0);
        }

        this.transform.position += new Vector3(movement.x, movement.y, 0) * Time.deltaTime;
    }
}