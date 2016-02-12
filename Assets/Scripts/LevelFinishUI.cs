using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinishUI : MonoBehaviour
{
    public Text scoreText;
    public Text resetCount;
    public GameObject scorePanel;
    public FinishBlock finishBlock;
    public Camera levelFinishedCamera;

    public float showScoreDelay;
    public float timeTaken = 0;

    private Camera mainCam;
    private ResetUI resetUI;
    private PlayerController playerController;

    private void Start()
    {
        mainCam = Camera.main;

        resetUI = gameObject.GetComponent<ResetUI>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (finishBlock.playerHasFinished)
        {
            StartCoroutine(DisplayScoreUI());
        }
    }

    private IEnumerator DisplayScoreUI()
    {
        yield return new WaitForSeconds(showScoreDelay);

        mainCam.gameObject.SetActive(false);
        levelFinishedCamera.gameObject.SetActive(true);

        playerController.isResetting = true;
        scorePanel.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);

        resetCount.gameObject.SetActive(false);

        scoreText.text = "Score-Board \nResets: " + resetUI.resets + "\nTime: " + timeTaken;
    }
}