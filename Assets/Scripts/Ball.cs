using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    GameManager gameManager;
    public Transform player;
    Vector2 plyrFirstPosition;
    Rigidbody2D rb2;
    public float moveSpeed = 10;
    public Text scoreText,hScoreText;
    public int Score { get; private set; }
    public int highScore { get; private set; }

    int Scr;
    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }
    public void LoadPlayer()
    {
        GameData data = SaveSystem.LoadGame();
        Score = data.score;
        Scr = data.score;
        Debug.Log("yuklendi"+Scr);
        

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        //position.z = data.position[3];
        player.transform.position = position;

    }
    // Start is called before the first frame update
    void Start()
    {
        ScnManagement();



        //Debug.Log("status"+status);

        plyrFirstPosition = player.position;

        //gameManager = GameObject.FindObjectOfType<GameManager>(); //tipi game manger olan nesneyi al

        Invoke("moveBall", 2f);

        LhighScore();

    }

    private void ScnManagement()
    {
        int sitatus = PlayerPrefs.GetInt("Sitatus");
        if(sitatus == 1)
        {
            LoadPlayer();
            scoreText.text = Score.ToString();
        }
    }

    private void LhighScore()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        hScoreText.text = highScore.ToString();
    }

    void moveBall()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(1, 0) * moveSpeed;
        Debug.Log(moveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //if (!gameManager.gameStarted) return; //oyun başlamamışsa çalıştırma
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        makeSkor();

    }

    private void makeSkor()
    {
        Score++;

        
        if (Score % 5 == 0) {

            float distance = Vector2.Distance(transform.position, player.transform.position);
            Debug.Log(distance);
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1);


            if (distance <= 3)
            {
                player.transform.position = new Vector2(player.transform.position.x, plyrFirstPosition.y);
                //gameManager.RestartGame(); //oyun yeniden basladı
                transform.position = new Vector2(0,4.23f);

            }
        }


        scoreText.text = Score.ToString();
        if (Score > highScore )
        {
            highScore = Score;
            
            hScoreText.text = highScore.ToString();

            PlayerPrefs.SetInt("highscore",highScore);
            SaveGame();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GetComponent<AudioSource>().Play();

    }
}
