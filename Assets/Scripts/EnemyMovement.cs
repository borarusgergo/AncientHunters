using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; //Sebess�g k�s�bb v�ltoz� type szerint
    public float moveDistance = 5f;
    public float gameOverThreshold = -5f; //Ez a k�perny� alja, enn�l feljebb vettem mert az utols� sorban nem lehet meg�lni az ellenfelet

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
            Debug.Log("Az ellens�g el�rte a hat�rt!");
            SceneManager.LoadScene("GameOver");
        }
    }

    void MoveEnemy()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        /* Ha m�g kellene a moveDistance de mostm�r faltol falig mozognak az enemyk
        if (Mathf.Abs(transform.position.x - startX) >= moveDistance)
        {
            //Lefele mozg�s
            direction *= -1; //�r�ny ford�t�s
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            startX = transform.position.x;
        }*/
        //K�perny� sz�l�n lefelemozog �s ir�nyt v�lt
        if (transform.position.x <= -screenBounds.x + objectWidth || transform.position.x >= screenBounds.x - objectWidth)
        {
            direction *= -1;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        }
    }
}
