using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;

    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject startGameButton;
    public bool gameState = false;

    [ContextMenu("Increase Score")]
    public void addScore(int score)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

    public void startGame()
    {
        
        startGameButton.SetActive(false);
        gameState = true;
        Debug.Log("111");
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameState = false;
        Debug.Log("3333");
    }

    public void gameOver()
    {
        Debug.Log("4444");
        gameOverScreen.SetActive(true);
        gameState = false;
        Debug.Log("4444");
    }

}
