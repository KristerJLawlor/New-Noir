using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeGood : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PlayerM;
    void Start()
    {
        PlayerM = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody Prig = PlayerM.GetComponent<Rigidbody>();
        transform.position = Vector3.Lerp(this.transform.position, new Vector3(Prig.position.x, 6, Prig.position.z), 0.01f);
        transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
