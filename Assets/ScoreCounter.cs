using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SCORE", 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        PlayerPrefs.SetInt("SCORE", PlayerPrefs.GetInt("SCORE"));
        score.text = "Score "+PlayerPrefs.GetInt("SCORE").ToString();
    }

    public void gotoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
