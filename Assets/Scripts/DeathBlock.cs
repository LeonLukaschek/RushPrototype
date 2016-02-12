using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeathBlock : MonoBehaviour
{
    public float damage;
    public float resetTime;
    public float resetDelay;

    [Header("Reset")]
    public Color resetColor;

    public Text resetText;
    public ResetUI resetUI;

    public Transform resetPosition;

    private Color startBackgroundColor;

    private PlayerController playerC;
    private GraplingHook hook;
    private Camera mainCam;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        mainCam = Camera.main;
        playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        hook = playerC.GetComponent<GraplingHook>();

        startBackgroundColor = mainCam.backgroundColor;
        resetText.gameObject.SetActive(false);
    }

    private void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player hit death block");
            StartCoroutine(ResetPlayer());
        }
    }

    private IEnumerator ResetPlayer()
    {
        playerC.isResetting = true;

        AddReset();

        playerC.GetComponent<MeshRenderer>().enabled = false;
        hook.ResetHook();

        mainCam.backgroundColor = resetColor;
        resetText.gameObject.SetActive(true);

        playerC.transform.position = resetPosition.position;
        playerC.GetComponent<MeshRenderer>().enabled = true;

        playerC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        yield return new WaitForSeconds(resetTime);

        yield return new WaitForSeconds(resetDelay);

        mainCam.backgroundColor = startBackgroundColor;
        resetText.gameObject.SetActive(false);

        playerC.isResetting = false;
    }

    public void AddReset()
    {
        resetUI.resets++;
    }
}