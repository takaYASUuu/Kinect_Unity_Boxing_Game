using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_UI1 : MonoBehaviour
{
    [SerializeField] GameObject FirePrefab;
    int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameDirector.rage_state1 == 1)
        {
            Instantiate(FirePrefab, transform.position, Quaternion.identity);
            state = 1;
        }
        if (GameDirector.rage_state1 == 0 && state == 1)
        {
            Destroy(FirePrefab);
            state = 0;
        }
    }
}
