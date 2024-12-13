using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float speed = 5f;
    public float acceleration = 10f;
    public float deceleration = 10f;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private float currentVelocity = 0f;

    void Start()
    {
        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null )
        {
            objectWidth = spriteRenderer.bounds.extents.x;
            objectHeight = spriteRenderer.bounds.extents.y;
        }
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //Gyorsulás és lassulás
        if (horizontal != 0)
        {
            currentVelocity = Mathf.MoveTowards(currentVelocity, horizontal * speed, acceleration * Time.deltaTime);
        }
        else
        {
            currentVelocity = Mathf.MoveTowards(currentVelocity, 0, deceleration * Time.deltaTime);
        }

        transform.Translate(Vector2.right * currentVelocity * Time.deltaTime);

        //Mozgás korlátozása
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);

        transform.position = position;
    }
}
