using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleController : MonoBehaviour
{
    public static ObstacleController Instance {get; private set;}

    [Header("Pooling configs")]
    [SerializeField] private Obstacle obstaclePrefab;
    [SerializeField] private int obstacleQuantity;
    [SerializeField] private float baseFrequency;
    
    private List<Obstacle> activatedObstacles = new List<Obstacle>();
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

    private void OnGetObstacle(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(true);
        obstacle.SetPosition();
        activatedObstacles.Add(obstacle);
    }

    private void OnReleaseObstacle(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(false);
        activatedObstacles.Remove(obstacle);
    }

    public void ActivateObstacleSystem(int difficultyChosen)
    {
        isActive = true;
        float matchSpawnFrequency = baseFrequency / difficultyChosen;
        spawnObstacleCo = StartCoroutine(SpawnObstacleCo(difficultyChosen, matchSpawnFrequency));
    }

    public void DisableObstacleSystem()
    {
        isActive = false;
        StopCoroutine(spawnObstacleCo);
        
        foreach(Obstacle obstacle in activatedObstacles)
        {
            obstacle.StopMovement();
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
