using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float flyVelocity = 5f;

    private const string FLEW_ANIMATION_TRIGGER = "Flew";
    
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();      
    }

    //Callback necessary for InputSystem
    public void OnFlyUp(InputAction.CallbackContext context)
    {
        if(context.performed) 
        {
            Fly();
        } 
    }

    private void Fly()
    {
        rb.velocity = Vector2.up * flyVelocity;
        SoundController.Instance.PlayFlySFX();
        
        // I think that's not necessary for now another script for animation, since the initial plan is to have only two
        animator.SetTrigger(FLEW_ANIMATION_TRIGGER);
    }
}
