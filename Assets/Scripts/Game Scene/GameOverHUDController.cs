using TMPro;
using UnityEngine;

public class GameOverHUDController : MonoBehaviour
{  
    [SerializeField] private Transform gameOverPanel;
    [SerializeField] private Transform highscoreMessage;

    private void Start()
    {
        highscoreMessage?.gameObject.SetActive(false);
    }

    public void OnCharacterDeath()
    {
        gameOverPanel?.gameObject.SetActive(true);
    }

    public void OnNewHighscoreReached()
    {
        highscoreMessage?.gameObject.SetActive(true);
    }
}
