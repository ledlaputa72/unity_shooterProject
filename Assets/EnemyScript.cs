using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyShot;
    public int type = 0;
    public int hp = 3;
    public float speed = 4;
    public float coin = 0;
    public float time;
    public float maxShotTime;
    public float shotSpeed;

    void Start()
    {
        //적별로 HP와 스피드 코인사이즈를 설정
        switch(type){
            case 0:
                hp=10; speed = 3.0f; coin = 3; maxShotTime = 3;  shotSpeed = 5;
                break;
            case 1:
                hp=20; speed = 2.0f; coin = 4; maxShotTime = 2;  shotSpeed = 4;
                break;
            case 2:
                hp=30; speed = 1.0f; coin = 5; maxShotTime = 1;  shotSpeed = 3;
                break;
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > maxShotTime){
            GameObject shotObj = Instantiate(enemyShot, transform.position, Quaternion.identity);
            EnemyShotScript shotScript = shotObj.GetComponent<EnemyShotScript>();
            //적의 각 샷 스피드를 shotScript의 스피드에 대입 
            shotScript.speed = shotSpeed;
            time = 0;
        }
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
