using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] List<float> heightValues = new List<float>();
    [SerializeField] float baseSpeed;

    Action<Obstacle> releaseCallback;

    const int X_BORDER_POSITION = 4; //Both x edges position is 4 (4 for spawning and -4 for finished position)

    bool isActive = false;
    float obstacleSpeed;

    public void SetPosition()
    {
        float randomHeight = heightValues[UnityEngine.Random.Range(0, heightValues.Count)]; 
        transform.position = new Vector2(X_BORDER_POSITION, randomHeight);
    }

    public void InitiateMovement(int difficultyChosen, Action<Obstacle> _releaseCallback)
    {
        releaseCallback ??= _releaseCallback;
        obstacleSpeed = baseSpeed * difficultyChosen;
        isActive = true;
    }

    void Update()
    {
        if(isActive)
        {
            transform.position += obstacleSpeed * Time.deltaTime * Vector3.left;
            if(transform.position.x < -X_BORDER_POSITION) { DisableObstacle(); }
        }
    }

    void DisableObstacle()
    {
        isActive = false;
        releaseCallback?.Invoke(this);
    }
}
