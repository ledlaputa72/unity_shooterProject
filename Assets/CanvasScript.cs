using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.

public class CanvasScript : MonoBehaviour
{
    public Text
    void Start()
    {
        print("Width"+ Screen.width);
        print("Height"+ Screen.height);

        print(Camera.main.ViewportToScreenPoint(new Vector3(0,0,0)));
        print(Camera.main.ViewportToScreenPoint(new Vector3(1,1,0)));
        Vector3 pos = Camera.main.ViewportToScreenPoint(new Vector3(0,0,0));
        myText.GetComponent<RectTransform>().position = pos;
    }

    void Update()
    {
        
    }
}
