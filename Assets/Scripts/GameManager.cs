using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOverScreen;

    private int playerScore = 0;

    [SerializeField]
    private Text scoreTxt;

    [SerializeField]
    private ParticleSystem particleSystem;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip gameOverSound;

    [SerializeField]
    private AudioClip pointSound;

    private void Awake()
    {
        if(audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    [ContextMenu("Increase Score")]
    public void UpdateScoreText()
    {
        if(scoreTxt != null)
        {
            playerScore++;
            scoreTxt.text = playerScore.ToString();
            if(audioSource != null && pointSound != null)
            {
                audioSource.PlayOneShot(pointSound);
            }
        }
    }

    public void RestartGame()
    {
        BirdScript.isBirdAlive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        if(particleSystem != null)
        {
            particleSystem.Pause();
        }
        if(audioSource != null && gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }
}
