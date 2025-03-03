using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject pauseMenu;
    public VoidEventChannel onPlayerDeath;
    
    private bool isPaused = false;

    private void OnEnable()
    {
        onPlayerDeath.OnEventRaised += Die;
    }

    private void OnDisable()
    {
        onPlayerDeath.OnEventRaised -= Die;
    }

    private void Die()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0; // Stop le temps quand le joueur meurt
    }

    void Start()
    {
        gameOverScreen.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1; // Assurez-vous que le jeu commence normalement
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Remettre le jeu en vitesse normale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
