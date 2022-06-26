using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class End_game : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI HighScore;

    private void Start()
    {
        HighScore.text = PlayerPrefs.GetInt("HIGH_SCORE",0).ToString();
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
    
}
