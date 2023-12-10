using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private InputController inputController;

    void Awake()
    {
        inputController = new InputController();
    }

    void Start()
    {
        inputController.Character.Movement.performed += MoveUp;
    }

    public void MoveUp(InputAction.CallbackContext context)
    {
        Debug.Log("interacted");
    }
}
