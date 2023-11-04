using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraMove : MonoBehaviour
{
    public GameObject Man_01;
    //GameObject FPSCamera;
    // Start is called before the first frame update
    void Start()
    {
        //Man_01 = GameObject.Find("Man_01");
        //FPSCamera = GameObject.Find("FPS Camera");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Man_01.transform.position.x, Man_01.transform.position.y , Man_01.transform.position.z);
        this.transform.eulerAngles = new Vector3(Man_01.transform.rotation.x, Man_01.transform.rotation.y, Man_01.transform.rotation.z);
    }
}
