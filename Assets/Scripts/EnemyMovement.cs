using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; //Sebesség késõbb változó type szerint
    public float gameOverThreshold = -5f; //Ez a képernyõ alja, ha ezt eléri Game Over
    public float downMovement = 1f; //Lefelé mozgás

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
            Debug.Log("Az ellenség elérte a határt!");
            SceneManager.LoadScene("GameOver");
        }
    }

    void MoveEnemy()
    {
        transform.Translate(direction * speed * GameManager.globalSpeedMulitplier *Time.deltaTime);

        //Képernyõ szélén lefelemozog és irányt vált
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
