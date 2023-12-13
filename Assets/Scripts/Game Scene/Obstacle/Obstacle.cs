using System;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private List<float> heightValues = new List<float>();
    [SerializeField] private float baseSpeed;

    private Action<Obstacle> releaseCallback;

    private const int X_BORDER_POSITION = 4; //Both x edges position is 4 (4 for spawning and -4 for finished position)

    private bool isActive = false;
    private float obstacleSpeed;

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

    private void Update()
    {
        if(isActive)
        {
            transform.position += obstacleSpeed * Time.deltaTime * Vector3.left;
            if(transform.position.x < -X_BORDER_POSITION) { DisableObstacle(); }
        }
    }

    private void DisableObstacle()
    {
        isActive = false;
        releaseCallback?.Invoke(this);
    }
}
