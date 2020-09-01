using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text myText;
    void Start()
    {
        print("Width"+ Screen.width);
        print("Height"+ Screen.height);

        print(Camera.main.ViewportToScreenPoint(new Vector3(0,0,0)));
        print(Camera.main.ViewportToScreenPoint(new Vector3(1,1,0)));
        Vector3 pos = Camera.main.ViewportToScreenPoint(new Vector3(0,0,0));
        myText.GetComponent<RectTransform>().position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        myText.GetComponent<RectTransform>().position = Input.mousePosition;   
    }
}
