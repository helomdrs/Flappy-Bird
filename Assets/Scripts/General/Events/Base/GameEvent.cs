using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "GameEvent")]
public class GameEvent<T> : ScriptableObject
{
    private List<EventListener<T>> listeners = new List<EventListener<T>>();

    public void TriggerEvent(T data)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered(data);
        }
    }

    public void AddListener(EventListener<T> listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(EventListener<T> listener)
    {
        listeners.Remove(listener);
    }
}
