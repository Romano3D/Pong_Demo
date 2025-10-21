using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;
    public Transform ball;

    public BallController ballController;

    public int playerScore = 0;
    public int enemyScore = 0;

    public int winPoints = 2;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    
    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        // Define as posições iniciais da raquetes
        playerPaddle.position = new Vector3(-6f, 0f, 0f);
        enemyPaddle.position = new Vector3(5.74f, 0f, 0f);

        // ...

        //Inserir dentro do ResetGame
        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = playerScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }
    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (enemyScore >= winPoints || playerScore >= winPoints)
        {
            //resetGame();
            EndGame();
        }
    }
    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Vitória" + winner;
        SaveController.Instance.SaveWinner(winner);

        Invoke("LoadMenu", 2f);
        
    }
    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
} 

