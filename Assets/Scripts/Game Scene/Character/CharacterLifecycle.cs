using UnityEngine;

public class CharacterLifecycle : MonoBehaviour
{
    private const string OBSTACLE_TAG = "Obstacle";
    private const string DIED_ANIMATION_TRIGGER = "Died";

    private Animator animator;

    private bool isAlive = true;

    public GameEvent<int> onCharacterDeath;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag(OBSTACLE_TAG))
        {
            CallCharacterDeath();
        }
    }

    private void CallCharacterDeath()
    {
        if (isAlive == true) 
        {
            isAlive = false;

            // I think that's not necessary for now another script for animation, since the initial plan is to have only two
            animator.SetTrigger(DIED_ANIMATION_TRIGGER);

            SoundController.Instance.PlayDeathSFX();
            onCharacterDeath?.TriggerEvent(0);
        }
    }
}
