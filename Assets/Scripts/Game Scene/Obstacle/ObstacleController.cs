using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleController : MonoBehaviour
{
    public static ObstacleController Instance {get; private set;}

    [Header("Pooling configs")]
    [SerializeField] private Obstacle obstaclePrefab;
    [SerializeField] private int obstacleQuantity;
    [SerializeField] private float baseFrequency;
    [SerializeField] private int difficultyChosen; //For testing, won't be needed after game cycle management
    
    private ObjectPool<Obstacle> obstaclePool;
    private Coroutine spawnObstacleCo;

    private bool isActive = false;

    private void Awake()
    {
        //Singleton setup
        if (Instance != null && Instance != this) { Destroy(this); } else { Instance = this; } 
        
        // Creation of ObjectPool
        obstaclePool = new ObjectPool<Obstacle>(
            () => Instantiate(obstaclePrefab), 
            OnGetObstacle, 
            OnReleaseObstacle, 
            defaultCapacity: obstacleQuantity
        );
    }

    //For testing, won't be needed after game cycle management
    private void Start() { ManageObstacleSystem(true, difficultyChosen); }

    private void OnGetObstacle(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(true);
        obstacle.SetPosition();
    }

    private void OnReleaseObstacle(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
    }

    // turn this into an event when doing game cycle management
    public void ManageObstacleSystem(bool toActivate, int difficultyChosen)
    {
        isActive = toActivate;
        if(isActive == true)
        {
            float matchSpawnFrequency = baseFrequency / difficultyChosen;
            spawnObstacleCo = StartCoroutine(SpawnObstacleCo(difficultyChosen, matchSpawnFrequency));
        } 
        else 
        {
            StopCoroutine(spawnObstacleCo);
        }
    }

    private void ReleaseObstacleCallback(Obstacle obstacle)
    {
        obstaclePool.Release(obstacle);
    }

    private IEnumerator SpawnObstacleCo(int difficultyChosen, float matchSpawnFrequency)
    {
        while(isActive)
        {
            Obstacle obstacle = obstaclePool.Get();
            obstacle.InitiateMovement(difficultyChosen, ReleaseObstacleCallback);
            yield return new WaitForSeconds(matchSpawnFrequency);
        }
    }
}
