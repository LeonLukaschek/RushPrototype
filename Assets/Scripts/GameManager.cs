using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Reset")]
    public Transform resetPosition;

    public GameObject scoreBoard;
    public Camera levelFinishedCamera;

    public FinishBlock finishBlock;

    public PlayerController playerController;
    public GameObject gameUI;

    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAll();
        }
    }

    public void ResetAll()
    {
        playerController.isResetting = true;
        finishBlock.playerHasFinished = false;

        playerController.transform.position = resetPosition.position;

        gameUI.GetComponent<LevelFinishUI>().StopAllCoroutines();

        gameUI.GetComponent<ResetUI>().resets = 0;
        gameUI.GetComponent<LevelFinishUI>().scoreText.text = "";

        scoreBoard.SetActive(false);
        gameUI.GetComponent<LevelFinishUI>().scoreText.gameObject.SetActive(false);

        gameUI.GetComponent<LevelFinishUI>().resetCount.gameObject.SetActive(true);

        levelFinishedCamera.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);

        playerController.isResetting = false;
    }
}