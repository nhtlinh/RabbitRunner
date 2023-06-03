using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public GameObject cactus;
    public float spawnTime;

    float m_spawnTime;
    int m_score;
    bool m_isGameOver;

    //Sound && Effect
    public AudioSource m_audioSource;

    //Ui
    uiManagement m_ui;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        //Start BackGround Sound
        m_audioSource.Play();
        //UI
        m_ui = FindObjectOfType<uiManagement>();
        //Set scrore = 0
        m_ui.setScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        //Time to create a new cactus
        m_spawnTime -= Time.deltaTime;

        if (m_isGameOver)
        {
            //Show Game Over Panel
            m_ui.showGameOverPanel(true);
            //Set m_spawnTime = 0
            m_spawnTime = 0;
            return;
        }

        if (m_spawnTime <= 0)
        {
            spawnCactus();
            if (m_score >= 10)
            {
                m_spawnTime = spawnTime - 0.2f;
            }
            else
            {
                m_spawnTime = spawnTime;
            }
        }
    }

    //Create Spawn Cactus
    public void spawnCactus()
    {
        //Position cactus create
        Vector2 spawnPos = new Vector2(16.35f,Random.Range(-2.12f,-0.93f));

        if (cactus)
        {
            Instantiate(cactus, spawnPos, Quaternion.identity);
        }
    }

    //Method Incremental Score
    public void incrementScore()
    {
        m_score++;
        //Set UI Score
        m_ui.setScoreText("Score: " + m_score);
    }

    //Play Start
    public void playGame()
    {
        SceneManager.LoadScene("GamePlay");
    }

    //Exit Application
    public void exit()
    {
        Application.Quit();
    }


    //Play Again
    public void playAgain()
    {
        SceneManager.LoadScene("GamePlay");
    }

    //Method Get & Set Score
    public void setScore(int value)
    {
        m_score = value;
    }

    public int getScore()
    {
        return m_score;
    }

    //Method Get & Set Gameover
    public void setIsGameOver(bool state)
    {
        m_isGameOver = state;
    }

    public bool getIsGameOver()
    {
        return m_isGameOver;
    }
}
