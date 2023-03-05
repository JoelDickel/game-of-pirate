using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{

    public static LevelController levelController;


    private float startWait = 5;

    public GameObject[] enemiChasers;
    public Boundary boundary;
    public Vector2 spawnWait;
    public int score;


    
    //GameOver
    public GameObject gameOverMenu;
    public Text scoreText;
    private bool gameOver = false;
    private int enemyCount = 1;


    //Btn Fire
    public Button fireSide;
    public Button fireFront;



    void Start()
    {
        
        gameOverMenu.SetActive(false);
        levelController = this;
        StartCoroutine(SpawnWaves());

        fireSide.onClick = new Button.ButtonClickedEvent();
        fireSide.onClick.AddListener(() => FindObjectOfType<Player>().SideFire());

        fireFront.onClick = new Button.ButtonClickedEvent();
        fireFront.onClick.AddListener(() => FindObjectOfType<Player>().FrontFire());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = enemiChasers[Random.Range(0, enemiChasers.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(boundary.xMin, boundary.xMax),boundary.yMin, 0);
                Instantiate(enemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait.x);
            }

            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = enemiChasers[Random.Range(0, enemiChasers.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(boundary.xMin, boundary.xMax), boundary.yMax, 0);
                Instantiate(enemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait.x);
            }

        }
    }

    public void SetScore(int scorePoints)
    {
        score += scorePoints;
        scoreText.text = score.ToString();
    }

    public void SalvaPontuacao()
    {
        if (gameOver)

            gameOverMenu.SetActive(true);
            PlayerPrefs.SetInt("score", score);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
}
