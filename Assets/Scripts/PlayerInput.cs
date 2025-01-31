using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private InputActionReference _actionReference;
    Vector2 playerPosition;
    Vector2 moveInput;
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    [SerializeField] private bool isGrounded;
    [SerializeField] public bool onLadder = false;
    public Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
       rb= GetComponent<Rigidbody2D>(); 
    }
    private void FixedUpdate()
    {
        if (onLadder)
        {
            Move();
          
        }
        else if (!onLadder)
        {
            MoveHorizontal();
        }
    }

    private void Update()
    {
        moveKeyboard();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Move()
    {
        if (Mathf.Abs(moveInput.x) > 0.1f || Mathf.Abs(moveInput.y) > 0.1f)
        {
            animator.SetBool("isWalking", true);
            rb.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);

            FlipCharacter(moveInput.x);
        }
        else { animator.SetBool("isWalking", false); }
    }

    private void MoveHorizontal()
    {
        if (Mathf.Abs(moveInput.x) > 0.1f)
        {
            animator.SetBool("isWalking", true);
            Vector3 movement = new Vector3(moveInput.x * moveSpeed * Time.deltaTime, 0, 0);
            transform.position += movement;

            FlipCharacter(moveInput.x);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void OnJump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    public void OnInteraction()
    {
    
        EventManager.TriggerJoystickClick();

        StartCoroutine(ResetButtonPress());

    }
    private void OnMove(InputValue value)
    {
        Vector2 inputSystemMove = value.Get<Vector2>();
        moveInput = inputSystemMove;
    }

    private void moveKeyboard()
    {
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardY = Input.GetAxis("Vertical");

        if (Mathf.Abs(keyboardX) > 0.01f || Mathf.Abs(keyboardY) > 0.01f)
        {
            moveInput = new Vector2(keyboardX, keyboardY);
        }
    }

    private void FlipCharacter(float moveDirection)
    {
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private IEnumerator ResetButtonPress()
    {
        yield return new WaitForSeconds(0.25f); 

    }
}
