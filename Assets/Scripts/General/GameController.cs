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

   public void OnMatchOver()
   {

   }
}
