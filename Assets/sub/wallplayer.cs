using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallplayer : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public GameObject Man_01;
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "kabe")
        {
            Debug.Log("Hit");
            m_Rigidbody.constraints = RigidbodyConstraints.None;
            Man_01.GetComponent<AvatarController>().enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
