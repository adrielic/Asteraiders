using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    private Vector2 playerPos, obstacPos;
    private Quaternion playerDir;
    private IEnumerator spawnCor, diffCor;
    private float obstacPosY, obstacPosX;
    private int obstacAmt;

    public static float gameSpeed;
    public GameObject player, background, cleaningZone;
    public GameObject[] walls, obstacles;
    public TMP_Text scoreDisplay;
    public TMP_Text highScoreDisplay;

    void Start()
    {
        InstantiatePlayer();
        InstantiateBackground();
        InstatiateWalls();
        InstantiateCleaningZone();

        gameSpeed = -2f;
        obstacAmt = 1;

        spawnCor = SpawnObstacles(1f);
        diffCor = IncreaseDifficulty(30f);
        StartCoroutine(spawnCor);
        StartCoroutine(diffCor);

        Debug.Log("Difficulty - Speed: " + gameSpeed + " / Asteroid amount: " + obstacAmt);
    }

    void Update()
    {
        scoreDisplay.text = "Score: " + Score.currentScore;
        highScoreDisplay.text = "High Score: " + Score.highScore;

        if (Player.isDead == true)
        {
            if (Score.currentScore > Score.highScore)
            {
                Score.highScore = Score.currentScore;
            }

            gameSpeed = 0;
            Player.isDead = false;
        }
    }

    void InstantiatePlayer()
    {
        playerPos = new Vector2(-7, 0);
        playerDir = Quaternion.Euler(0f, 0f, -90f);
        Instantiate(player, playerPos, playerDir);
    }

    void InstantiateBackground()
    {
        Instantiate(background);
    }

    void InstatiateWalls()
    {
        for (int i = 0; i < walls.Length; i++)
        {
            Instantiate(walls[i]);
        }
    }

    void InstantiateCleaningZone()
    {
        Instantiate(cleaningZone);
    }

    void InstantiateObstacles()
    {
        for (int i = 0; i < obstacAmt; i++)
        {
            int rPrefab = Random.Range(0, 3);
            obstacPosX = Random.Range(10f, 50f);

            if (rPrefab == 0)
            {
                obstacPosY = Random.Range(-4f, 4f);
            }
            else if (rPrefab == 1)
            {
                obstacPosY = Random.Range(-3.8f, 3.8f);
            }
            else if (rPrefab == 2)
            {
                obstacPosY = Random.Range(-3.6f, 3.6f);
            }

            obstacPos = new Vector2(obstacPosX, obstacPosY);
            Instantiate(obstacles[rPrefab], obstacPos, Quaternion.identity);
        }
    }

    IEnumerator SpawnObstacles(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            InstantiateObstacles();

            Score.currentScore += 1;
            Debug.Log("Score: " + Score.currentScore);
        }
    }

    IEnumerator IncreaseDifficulty(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            gameSpeed--;

            if (gameSpeed >= -5f)
            {
                obstacAmt = 1;
                Score.currentScore += 5;
            }
            if (gameSpeed <= -5f)
            {
                obstacAmt = 2;
                Score.currentScore += 5;
            }
            if (gameSpeed <= -10f)
            {
                obstacAmt = 3;
                Score.currentScore += 5;
            }
            if (gameSpeed <= -15f)
            {
                obstacAmt = 4;
                Score.currentScore += 5;
            }
            if (gameSpeed <= -20f)
            {
                obstacAmt = 5;
                Score.currentScore += 5;
            }
            if (gameSpeed <= -25f)
            {
                obstacAmt = 6;
                gameSpeed = -25f;
                Score.currentScore += 5;
            }

            Debug.Log("Increasing difficulty - Speed: " + gameSpeed + " / Asteroid amount: " + obstacAmt);
        }
    }
}
