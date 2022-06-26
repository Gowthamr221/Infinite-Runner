using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool isGamePaused=false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameButtons;
    private void Start()
    {
        ResumeGame();
    }
    public void PauseGame()
    {
        isGamePaused = true;
        gameButtons.SetActive(false);
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        isGamePaused=false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameButtons.SetActive(true);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
