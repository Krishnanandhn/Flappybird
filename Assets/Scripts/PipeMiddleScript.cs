using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(gameManager != null)
            {
                gameManager.UpdateScoreText();
            }
        }
    }
}
