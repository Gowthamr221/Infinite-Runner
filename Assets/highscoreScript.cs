using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class highscoreScript : MonoBehaviour
{
    int temp;
    // Start is called before the first frame update
    

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            temp = PlayerPrefs.GetInt("SCORE",0);
            PlayerPrefs.SetInt("SCORE", temp + 1);
            Destroy(this.gameObject);
        }
    }
}
