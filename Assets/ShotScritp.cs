using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScritp : MonoBehaviour
{
    public GameObject shotEffect; //피격 당하면 생기는 이펙트 
    public GameObject coin; //코인
    public GameObject explosion; //폭발 이펙트 
    public float speed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //발사체 이동 
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("OntriggerEnter2D" + collision.tag);
        if(collision.tag == "Asteroid")
        {
            AstroidScript astroidScript = collision.gameObject.GetComponent<AstroidScript>();
            astroidScript.hp -= 3;
            //폭발위치 보정
            Vector3 editPos = new Vector3(-0.1f, 0, 0);
            //폭발 이펙트 
            Instantiate(shotEffect, transform.position + editPos, Quaternion.identity);
            //HP가 다되면 폭파 사라짐 
            if (astroidScript.hp <= 0)
            {
                //운석 폭발 이펙트 
                Instantiate(explosion, transform.position, Quaternion.identity);
                Vector3 randomPos = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
                //운석 터지면 코인 등장 
                Instantiate(coin, transform.position + randomPos, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }
    }

    //화면 밖으로 나간 발사체 제거하는 함수 
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
