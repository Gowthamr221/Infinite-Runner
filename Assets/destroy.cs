using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision Detected");
        PlayerPrefs.SetInt("SCORE", PlayerPrefs.GetInt("SCORE", 0) + 1);
        Destroy(this.gameObject);
    }
}
