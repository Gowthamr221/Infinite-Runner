using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class start_game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HighScore;
    // Start is called before the first frame update
    private void Start()
    {
          
        HighScore.text = "High Score " + PlayerPrefs.GetInt("HIGH_SCORE", 0).ToString();
    }
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
