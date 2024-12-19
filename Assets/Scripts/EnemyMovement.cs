using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; //Sebess�g k�s�bb v�ltoz� type szerint
    public float gameOverThreshold = -5f; //Ez a k�perny� alja, ha ezt el�ri Game Over
    public float downMovement = 1f; //Lefel� mozg�s

    private Vector2 direction = Vector2.right;
    private float startX;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private bool hasBounced = false;

    void Start()
    {
        startX = transform.position.x;

        Camera mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            objectWidth = spriteRenderer.bounds.extents.x;
            objectHeight = spriteRenderer.bounds.extents.y;
        }
    }

    void Update()
    {
        MoveEnemy();

        if(transform.position.y <= gameOverThreshold)
        {
            Debug.Log("Az ellens�g el�rte a hat�rt!");
            SceneManager.LoadScene("GameOver");
        }
    }

    void MoveEnemy()
    {
        transform.Translate(direction * speed * GameManager.globalSpeedMulitplier *Time.deltaTime);

        //K�perny� sz�l�n lefelemozog �s ir�nyt v�lt
        if (transform.position.x <= -screenBounds.x + objectWidth || transform.position.x >= screenBounds.x - objectWidth)
        {
            if (!hasBounced)
            {
                direction *= -1;
                transform.position = new Vector3(transform.position.x, transform.position.y - downMovement, transform.position.z);
                hasBounced = true;
            }
        }
        else
        {
            hasBounced = false;
        }
    }
}
