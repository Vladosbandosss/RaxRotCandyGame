using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] Text scoreText;
    public static GameManager instanse;
    int score = 0;
    [SerializeField] GameObject livesHolder;
    bool gameOver = false;

    int lives = 3;

    [SerializeField] GameObject overPanel;
    
    private void Awake()
    {
        if (instanse == null)
        {
            instanse = this;
        }
    }
    
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementScore()
    {
        if (!gameOver)
        {
            
            score++;
            scoreText.text = score.ToString();
            
        }
       
    }

    public void DecreAseLife()
    {
        if (lives > 0)
        {
            lives--;
            livesHolder.transform.GetChild(lives).gameObject.SetActive(false);
          
        }
        if (lives <= 0)
        {
            gameOver = true;
            GameOver();
        }
        
        
    }

    public void GameOver()
    {
        CandySpawner.instanse.StopSpawning();
        GameObject.Find("Player").GetComponent<PlayerController>().CanMove = false;
        overPanel.SetActive(true);
    }

    public void RestarGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MenuCome()
    {
        SceneManager.LoadScene("Menu");
    }
}
