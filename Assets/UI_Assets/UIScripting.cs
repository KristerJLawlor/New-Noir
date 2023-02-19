using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScripting : MonoBehaviour
{
    public Text Lives;
    public Text Ammo;
    // Start is called before the first frame update
    void Start()
    {
        Lives.text = "3";
        Ammo.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeLives(int livesCount)
    {
        Lives.text = ""+livesCount;
    }
    public void changeAmmo(int AmmoCount)
    {
        Ammo.text = "" + AmmoCount;
    }
}
