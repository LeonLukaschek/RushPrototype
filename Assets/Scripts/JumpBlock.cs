using System.Collections;
using UnityEngine;

public class JumpBlock : MonoBehaviour
{
    public float jumpForce;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerC;
            playerC = other.gameObject.GetComponent<PlayerController>();

            Bounce(other.gameObject);
        }
    }

    public void Bounce(GameObject other)
    {
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpForce);
    }
}