using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject Man_01;
    // Start is called before the first frame update
    void Start()
    {
        Man_01.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 100);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
