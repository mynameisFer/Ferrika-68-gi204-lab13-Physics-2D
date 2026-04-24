using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Vector2 force = new Vector2(20f, 0f);
    Rigidbody2D rb2d;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}