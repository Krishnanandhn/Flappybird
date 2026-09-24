using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    private float jumpForce = 10f;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip jumpSound;

    public static bool isBirdAlive = true;

    void Start()
    {
        gameObject.name = "Flappy Bird";
        if(rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isBirdAlive)
        {
            rigidBody.linearVelocity = Vector2.up * jumpForce;
            if(audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if(gameManager != null)
            {
                isBirdAlive = false;
                transform.GetComponent<Collider2D>().enabled = false;
                gameManager.GameOver();
            }
        }
    }
}
