using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private void Awake() { 
    
        for(int i=1;i<500;i++){
        Instantiate(prefab,new Vector3(i*35,-0.9f,1),Quaternion.identity);
        }
        
    }
}
