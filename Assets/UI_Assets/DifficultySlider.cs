using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySlider : MonoBehaviour
{
    public Slider Difficulty;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        //player.GetComponent<Player>().lives=
    }

    // Update is called once per frame
    void Update()
    {
        if(Difficulty.value == 0)
        {
            player.GetComponent<Player>().lives = 5;
        }
        if (Difficulty.value == 1)
        {
            player.GetComponent<Player>().lives = 4;
        }
        if (Difficulty.value == 2)
        {
            player.GetComponent<Player>().lives = 3;
        }
        if (Difficulty.value == 3)
        {
            player.GetComponent<Player>().lives = 1;
        }
    }
}
