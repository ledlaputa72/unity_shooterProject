using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject explosion;
    public GameObject shot;
    public float speed = 5;
    Vector3 min, max;
    Vector2 colSize;
    Vector2 chrSize;
    void Start()
    {
       
        min = new Vector3(-8, -4.5f, 0);
       //print(min);
        //max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        max = new Vector3(8, 4.5f, 0);
       //print(max);

        colSize = GetComponent<BoxCollider2D>().size;
        chrSize = new Vector2(colSize.x / 2, colSize.y / 2);

    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0).normalized;
        transform.position = transform.position + dir * Time.deltaTime * speed;

        float newX = transform.position.x;
        float newY = transform.position.y;

        //Clamp를 사용하여 비행기 화면밖으로 안나가게 적용 
        newX = Mathf.Clamp(newX, min.x + chrSize.x, max.x - chrSize.x);
        newY = Mathf.Clamp(newY, min.y + chrSize.y, max.y - chrSize.y);
        transform.position = new Vector3(newX, newY, transform.position.z);


        Move();
        PlayerShot();
        
    }

    //플레이어가 코인 오브젝트와 충돌     
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Item"){
            CoinScript coinScript = collision.gameObject.GetComponent<CoinScript>();
            //게임 오브젝트의 인스턴트에서 코인을 누적 
            GameManager.instance.coin += coinScript.coinSize;
            print("Coin: " + GameManager.instance.coin);
            GameManager.instance.coinText.text = GameManager.instance.coin.ToString();
            //코인을 파괴한다. 
            Destroy(collision.gameObject);
        }
        //플레이어에 운석/적 등이 충돌할때 캐릭터 파괴 
        else if(collision.gameObject.tag == "Asteroid" || 
        collision.gameObject.tag == "Enemy" ||
        collision.gameObject.tag == "EnemyShot" )  {
            Destroy(collision.gameObject); //충돌한 물체 파괴 
            Destroy(gameObject); //자신 파괴
            Instantiate(explosion, transform.position, Quaternion.identity); //폭파 이펙트 생성 
        }
    }


    //총알 발사하기 
    public float shotMax = 0.5f;
    public float shotDelay = 0;
    void PlayerShot()
    {
        shotDelay += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if(shotDelay > shotMax)
            {
                shotDelay = 0;
                //발사체 생성 위치 
                Vector3 vec = new Vector3(transform.position.x + 1.12f,
                transform.position.y - 0.17f, transform.position.z);
                Instantiate(shot, vec, Quaternion.identity);
            }
        }
        
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
    }
}

