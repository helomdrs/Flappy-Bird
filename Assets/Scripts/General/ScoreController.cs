using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    Coroutine countScoreCo;

    private int score = 0;
    private bool isCounting = false;

    //This is just for testing
    void Start(){ StartCountingScore(2); }

    //Connect this to gamecycle management latter
    public void StartCountingScore(int difficultyChosen)
    {
        score = 0;
        isCounting = true;
        countScoreCo = StartCoroutine(CountScoreCo(difficultyChosen));
    }

    public void StopCountingScore()
    {
        isCounting = false;
        StopCoroutine(countScoreCo);
        CheckForHighscore();
    }

    private void CheckForHighscore()
    {
       if (GameDataHolder.instance != null)
        {
            if(score > GameDataHolder.instance.GetHighscore())
            {
                GameDataHolder.instance.SetHighscore(score);
                Debug.Log("Got new highscore! " + score);
            }
        }   
    }

    private IEnumerator CountScoreCo(int difficultyChosen)
    {
        while(isCounting) 
        {
            score += 1 * difficultyChosen;
            UpdateHUD();
            yield return new WaitForSeconds(1);
        }
    }

    private void UpdateHUD()
    {
        scoreText.text = score.ToString();
    }
}
