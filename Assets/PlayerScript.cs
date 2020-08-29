using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
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

