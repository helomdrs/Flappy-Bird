using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameEvent<int> onMatchStart;

    void Start()
    {
        if (GameDataHolder.instance != null)
        {
            onMatchStart?.TriggerEvent(GameDataHolder.instance.GetDifficultyChosen());
        }
    }

    public void OnMatchOver(bool toRestart) 
    {
        if(toRestart)
        {
            HandleMatchRestart();
        } 
        else 
        {
            BackToMainScreen();
        }
    }

    private void HandleMatchRestart()
    {
       ScenesLoader.Instance.LoadGameScene();
    }

    private void BackToMainScreen()
    {
        ScenesLoader.Instance.LoadStartScene();
    }
}
