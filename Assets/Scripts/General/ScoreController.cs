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
    void Start(){ StartCountingScore(); }

    //Connect this to gamecycle management latter
    public void StartCountingScore()
    {
        score = 0;
        isCounting = true;
        countScoreCo = StartCoroutine(CountScoreCo());
    }

    public void StopCountingScore()
    {
        isCounting = false;
        StopCoroutine(countScoreCo);
    }

    private IEnumerator CountScoreCo()
    {
        while(isCounting) 
        {
            score += 1;
            UpdateHUD();
            yield return new WaitForSeconds(1);
        }
    }

    private void UpdateHUD()
    {
        scoreText.text = score.ToString();
    }
}
