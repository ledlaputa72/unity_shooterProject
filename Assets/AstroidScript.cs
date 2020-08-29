using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{
    public float speed = 5;
    public float rotSpeed = 30; //운석 회전 속도
    public int hp = 10;

    void Update()
    {
        //transform.position += Vector3.left * speed * Time.deltaTime;
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotSpeed));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
