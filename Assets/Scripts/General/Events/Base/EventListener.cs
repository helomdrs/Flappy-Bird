using UnityEngine;
using UnityEngine.Events;

public class EventListener<T> : MonoBehaviour
{
    public GameEvent<T> gameEvent;
    public UnityEvent<T> unityEvent;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }

    public void OnEventTriggered(T data)
    {
        unityEvent?.Invoke(data);
    }
}