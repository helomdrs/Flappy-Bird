using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{
    private const string START_SCENE_NAME = "StartScene";
    private const string GAME_SCENE_NAME = "GameScene";

    public void LoadStartScene()
    {
        SceneManager.LoadScene(START_SCENE_NAME, LoadSceneMode.Single);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE_NAME, LoadSceneMode.Single);
    }
}
