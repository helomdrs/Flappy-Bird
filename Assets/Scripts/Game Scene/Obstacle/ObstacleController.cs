using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObstacleController : MonoBehaviour
{
    public static ObstacleController Instance {get; private set;}

    [Header("Pooling configs")]
    [SerializeField] Obstacle obstaclePrefab;
    [SerializeField] int obstacleQuantity;
    [SerializeField] float baseFrequency;
    [SerializeField] int difficultyChosen; //For testing, won't be needed after game cycle management
    
    ObjectPool<Obstacle> obstaclePool;
    Coroutine spawnObstacleCo;

    bool isActive = false;

    void Awake()
    {
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
    void Start() { ManageObstacleSystem(true, difficultyChosen); }

    void OnGetObstacle(Obstacle obstacle)
    {
        obstacle.gameObject.SetActive(true);
        obstacle.SetPosition();
    }

    void OnReleaseObstacle(Obstacle obstacle)
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

    void ReleaseObstacleCallback(Obstacle obstacle)
    {
        obstaclePool.Release(obstacle);
    }

    IEnumerator SpawnObstacleCo(int difficultyChosen, float matchSpawnFrequency)
    {
        while(isActive)
        {
            Obstacle obstacle = obstaclePool.Get();
            obstacle.InitiateMovement(difficultyChosen, ReleaseObstacleCallback);
            yield return new WaitForSeconds(matchSpawnFrequency);
        }
    }
}
