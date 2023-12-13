using UnityEngine;

public class DifficultyHolder : MonoBehaviour
{
    public static DifficultyHolder instance;

    //Diffulcty index: 1 - Easy / 2 - Normal / 3 - Hard
    [SerializeField] private int difficultyChosen = 2;

    private void Awake()
    {
        //creates the instance of the object that will hold the difficulty chosen information, keeping it from being destroyed
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetDifficulty(int difficulty) { difficultyChosen = difficulty; }
    public int GetDifficultyChosen() { return difficultyChosen; }
}
