using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameObject.Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player") 
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().lives--;
        }
    }
}
