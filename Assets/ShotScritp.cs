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
            Vector3 editPos = new Vector3(0, 0, 0);
            //폭발 이펙트 
            Instantiate(shotEffect, transform.position + editPos, Quaternion.identity);
            //HP가 다되면 폭파 사라짐 
            if (astroidScript.hp <= 0)
            {
                //운석 폭발 이펙트 
                Instantiate(explosion, transform.position, Quaternion.identity);
                Vector3 randomPos = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
                //운석 터지면 코인 등장 (코인 게임오브제트생성)
                GameObject coinObj = Instantiate(coin, transform.position + randomPos, Quaternion.identity);
                //코인 스크립트의 코인 사이즈에 운석 코인 값을 대입
                CoinScript coinScript = coinObj.GetComponent<CoinScript>(); 
                coinScript.coinSize = astroidScript.coin;
                //운석 파괴
                Destroy(collision.gameObject);
                
            }
            Destroy(gameObject);

         } else if (collision.tag == "Enemy")
        {
            EnemyScript EnemyScript = collision.gameObject.GetComponent<EnemyScript>();
            EnemyScript.hp -= 3;
            //폭발위치 보정
            Vector3 editPos = new Vector3(0, 0, 0);
            //폭발 이펙트 
            Instantiate(shotEffect, transform.position + editPos, Quaternion.identity);
            //HP가 다되면 폭파 사라짐 
            if (EnemyScript.hp <= 0)
            {
                //운석 폭발 이펙트 
                Instantiate(explosion, transform.position, Quaternion.identity);
                Vector3 randomPos = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), 0);
                //운석 터지면 코인 등장 (게임 오브젝트로)
                GameObject coinObj = Instantiate(coin, transform.position + randomPos, Quaternion.identity);
                //코인 스크립트에서 코인 사이즈를 가져와 적코인 사이즈를 대입
                CoinScript coinScript = coinObj.GetComponent<CoinScript>();
                coinScript.coinSize = EnemyScript.coin;
                //적 오브젝트를 파괴
                Destroy(collision.gameObject);
                
            }
            Destroy(gameObject);

        }
    }

    //화면 밖으로 나간 발사체 제거하는 함수 
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
