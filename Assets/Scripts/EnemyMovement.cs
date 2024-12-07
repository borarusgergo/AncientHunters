using UnityEngine;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; //Sebess�g k�s�bb v�ltoz� type szerint
    public float moveDistance = 5f;
    private Vector2 direction = Vector2.right;
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - startX) >= moveDistance)
        {
            direction *= -1; //Lefele mozg�s
            transform.position += Vector3.down * 0.5f;
        }
    }
}
