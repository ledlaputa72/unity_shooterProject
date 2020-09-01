using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public Text coinText;
    public static GameManager instance; //다른 스크립트에서 게임 매니저에 접근 가능하게 만들어 주는 객체 변수 생성. 
    public GameObject astroid;
    public List<GameObject> enemies;
    public float time = 0;
    public float maxTime = 2;
    public float coin;
    public float maxRight;
    private void Awake() {
        instance = this; //자기 자신을 대입하여 다른 곳에서 게임매니저 객체에 접근이 가능
    }    void Start()
    {
        coin = 0;
        coinText.text = coin.ToString();
        maxRight = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0)).x;
        print(maxRight);
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > maxTime){
            int check = Random.Range(0,2);
            if(check == 0 ){
                Instantiate(astroid, new Vector3(maxRight + 2, Random.Range(-4.0f, 4.0f), 0), 
                Quaternion.identity);
            
            }else{
                int type = Random.Range(0,3);
                Instantiate(enemies[type], new Vector3(maxRight + 2, Random.Range(-4.0f, 4.0f), 0), 
                Quaternion.identity);
            
            }
            
            time = 0;
        }
    }

    public void PauseAction(){
        
        Time.timeScale = 0; //게임을 멈추게 한다. (1은 다시동작)
        pausePanel.SetActive(true); //퍼즈패널을 활성화
        print("PuaseAction");
    }

    public void ResumeAction(){
        
        Time.timeScale = 1; //게임을 다시 실행
        pausePanel.SetActive(false); //퍼즈패널을 가리기
        print("ResumeAction");
    }

    public void MainManuAction(){
        
        Time.timeScale = 1; //게임을 다시 실행
        pausePanel.SetActive(false); //퍼즈패널을 활성화
        print("MainManuAction");
        SceneManager.LoadScene("MenuScene");
    }
}
