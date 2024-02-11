using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = false;
    public static int score;
    public static int lives;
    public AudioClip gameOverSound;

    public TMP_Text scoreText;
    public TMP_Text livesText;

    private void Awake()
    {
        score = 0;
        lives = 3;
        isGameOver = false;
    }

    private void Update()
    {
        scoreText.text = $"{score}";
        livesText.text = $"{lives}";

        if(lives <= 0)
        {
            lives = 0;
            if(!isGameOver)
            {
                GameOver();
            }
        }
    }

    public static void SetScore(int a)
    {
        score = a;
    }
    void GameOver()
    {
        AudioSystem.Play(gameOverSound);
        isGameOver = true;
        lives = 0;
        livesText.text = $"{0}";
    }
}
