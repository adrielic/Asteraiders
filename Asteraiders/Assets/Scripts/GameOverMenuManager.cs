using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenuManager : MonoBehaviour
{
    public TMP_Text highScoreDisplay;

    void Start()
    {
        highScoreDisplay.text = "High Score: " + Score.highScore;
    }

    public void Retry()
    {
        GameController.gameSpeed = -2f;
        Score.currentScore = 0;
        SceneManager.LoadScene(1, LoadSceneMode.Single);

        Debug.Log(GameController.gameSpeed); 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
