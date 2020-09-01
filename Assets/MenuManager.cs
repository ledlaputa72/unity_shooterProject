using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //씬 관리를 위해 필요한 네임스페이스 

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoGameScene(){
        //씬 이동 함수 
        SceneManager.LoadScene("GameScene");
    }

    public void Quit(){
        //게임 종료
        Application.Quit();
    }
}
