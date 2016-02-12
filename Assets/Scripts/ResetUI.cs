using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ResetUI : MonoBehaviour
{
    public int resets;

    public Text resetText;

    private DeathBlock deathBlock;
    private PlayerController playerC;

    private void Start()
    {
        playerC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        resetText.text = "Resets: " + resets;
    }
}