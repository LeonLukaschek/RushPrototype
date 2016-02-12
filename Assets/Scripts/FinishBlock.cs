using System.Collections;
using UnityEngine;

public class FinishBlock : MonoBehaviour
{
    public bool playerHasFinished;

    private void Start()
    {
        playerHasFinished = false;
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Finished");
            playerHasFinished = true;
        }
    }
}