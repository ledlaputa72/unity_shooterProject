using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject astroid;
    public float time = 0;
    public float maxTime = 2;
    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > maxTime){
            time = 0;
            Instantiate(astroid, new Vector3(10, Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
        }
    }
}
