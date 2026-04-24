using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public InputAction moveAction;
    public InputAction jumpAction;

    public float jumpForce;
    public int countJump;
    public int maxJump = 2;

    Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        moveAction = moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        var hinput = moveAction.ReadValue<Vector2>().x;
        rb2d.linearVelocity = new Vector2(hinput * Speed, rb2d.linearVelocity.y);


        if (jumpAction.triggered && countJump < maxJump)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, 0f);
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            countJump++;
            Debug.Log("Jump : " + countJump);
        }




    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Debug.Log("Get Coin");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            countJump = 0;
        }
    }
}