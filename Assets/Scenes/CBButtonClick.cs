using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CBButtonClick : MonoBehaviour
{
    public Button button;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(Task);
        cam.GetComponent<Wilberforce.Colorblind>().Type = 0;
    }
    public void Task()
    {
        if (button.tag == "Normal")
        {
            //Set cam value to 0
            cam.GetComponent<Wilberforce.Colorblind>().Type = 0;
            Debug.Log(cam.GetComponent<Wilberforce.Colorblind>().Type);
        }
        if (button.tag == "Protanopia")
        {
            //set cam value to 1
            cam.GetComponent<Wilberforce.Colorblind>().Type = 1;
            Debug.Log(cam.GetComponent<Wilberforce.Colorblind>().Type);
        }
        if (button.tag == "Deuteranopia")
        {
            //set cam value to 2
            cam.GetComponent<Wilberforce.Colorblind>().Type = 2;
            Debug.Log(cam.GetComponent<Wilberforce.Colorblind>().Type);
        }
        if (button.tag == "Tritanopia")
        {
            //set cam value to 3
            cam.GetComponent<Wilberforce.Colorblind>().Type = 3;
            Debug.Log(cam.GetComponent<Wilberforce.Colorblind>().Type);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
