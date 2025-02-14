using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class currentscenemanager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public VoidEventChannel onPlayerDeath;
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
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }
}
