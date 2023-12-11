using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float flyVelocity = 5f;
    [SerializeField] AudioClip flySfx;

    const string FLEW_ANIMATION_TRIGGER = "Flew";

    Rigidbody2D rb;
    Animator animator;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    //Callback necessary for InputSystem
    public void OnFlyUp(InputAction.CallbackContext context)
    {
        if(context.performed) 
        {
            Fly();
        } 
    }

    void Fly()
    {
        rb.velocity = Vector2.up * flyVelocity;
        animator.SetTrigger(FLEW_ANIMATION_TRIGGER);
        PlayFlySFX();

    }

    void PlayFlySFX()
    {
        audioSource.clip = flySfx;
        audioSource.Play();
    }


}
