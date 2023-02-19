using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KMS());
    }
    public void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(this.gameObject);
    }
    public IEnumerator KMS()
    {
        yield return new WaitForSeconds(2);
        GameObject.Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
