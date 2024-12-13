using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; //Sebesség késõbb változó type szerint
    public float moveDistance = 5f;
    public float gameOverThreshold = -5f; //Ez a képernyõ alja, ennél feljebb vettem mert az utolsó sorban nem lehet megölni az ellenfelet

    private Vector2 direction = Vector2.right;
    private float startX;

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

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
        transform.Translate(direction * speed * Time.deltaTime);

        /* Ha még kellene a moveDistance de mostmár faltol falig mozognak az enemyk
        if (Mathf.Abs(transform.position.x - startX) >= moveDistance)
        {
            //Lefele mozgás
            direction *= -1; //írány fordítás
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            startX = transform.position.x;
        }*/
        //Képernyõ szélén lefelemozog és irányt vált
        if (transform.position.x <= -screenBounds.x + objectWidth || transform.position.x >= screenBounds.x - objectWidth)
        {
            direction *= -1;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        }
    }
}
