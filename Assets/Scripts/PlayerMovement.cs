using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput playerInput;
    private InputAction moveAction;
    private Animator animator;

    private float speed = 5.0f;
    private Vector2 direction;
    private Vector2 velocity;

    void Start()
    {
        moveAction = playerInput.actions.FindAction("Move"); 
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
        velocity = speed * direction * Time.deltaTime;
        transform.Translate(velocity);

        animator.SetFloat("InputX", direction.x);
        animator.SetFloat("InputY", direction.y);

        if (direction != Vector2.zero)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("LastInputX", direction.x);
            animator.SetFloat("LastInputY", direction.y);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
