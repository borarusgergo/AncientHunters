using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float speed = 5f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);
    }
}
