using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //다른 스크립트에서 게임 매니저에 접근 가능하게 만들어 주는 객체 변수 생성. 
    public GameObject astroid;
    public List<GameObject> enemies;
    public float time = 0;
    public float maxTime = 2;
    public float coin;
    private void Awake() {
        instance = this; //자기 자신을 대입하여 다른 곳에서 게임매니저 객체에 접근이 가능
    }    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > maxTime){
            int check = Random.Range(0,2);
            if(check == 0 ){
                Instantiate(astroid, new Vector3(10, Random.Range(-4.0f, 4.0f), 0), 
                Quaternion.identity);
            
            }else{
                int type = Random.Range(0,3);
                Instantiate(enemies[type], new Vector3(10, Random.Range(-4.0f, 4.0f), 0), 
                Quaternion.identity);
            
            }
            
            time = 0;
        }
    }
}
