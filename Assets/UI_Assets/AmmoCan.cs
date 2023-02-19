using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCan : MonoBehaviour
{
    //public int bullets;
    public int MaxBullets;

    public Image[] BC;
    public Sprite BF;
    public Sprite BE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateBullet(int bullets)
    {
        if (bullets > MaxBullets)
        {
            bullets = MaxBullets;
        }
        for (int i = 0; i < BC.Length; i++)
        {
            if (i < bullets)
            {
                BC[i].sprite = BF;
            }
            else
            {
                BC[i].sprite = BE;
            }
            if (i < MaxBullets)
            {
                BC[i].enabled = true;
            }
            else
            {
                BC[i].enabled = false;
            }
        }
    }
}
