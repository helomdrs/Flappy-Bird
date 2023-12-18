using TMPro;
using UnityEngine;

public class GameOverHUDController : MonoBehaviour
{  
    private Transform gameOverPanel;
    private Transform highscoreMessage;

    private void Start()
    {
        gameOverPanel = gameObject.transform.Find("GameOverPanel");
        highscoreMessage = gameOverPanel.transform.Find("HighscoreMessage");
        highscoreMessage?.gameObject.SetActive(false);
    }

    public void OnCharacterDeath()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    public void OnNewHighscoreReached()
    {
        highscoreMessage.gameObject.SetActive(true);
    }
}
