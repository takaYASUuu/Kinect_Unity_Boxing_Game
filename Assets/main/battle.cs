using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle : MonoBehaviour
{
    int guard_count = 0;
    int body_count = 0;
    int hand_state = 0;
    int hand_count = 0;
    int guard_state = 0;
    int body_state = 0;
    float start_time;
    float cooltime = 1.0f;
    List<GameObject> colList = new List<GameObject>();
    public static int damege_state1 = 0;
    public static int guardsuccess_state1 = 0;
    [SerializeField] GameObject hitPrefab;
    [SerializeField] GameObject guardPrefab;
    [SerializeField] GameObject ragePrefab;
    public AudioClip hitSE1;
    public AudioClip hitSE2;
    public AudioClip hitSE3;
    public AudioClip guardSE;
    public AudioClip rageSE;
    void OnCollisionEnter(Collision other)
    {
        if ((gameObject.tag == "hand") && Time.time - start_time > cooltime)
        {
            colList.Add(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - start_time > cooltime && colList.Count >= 1)
        {
            foreach (GameObject checkObj in colList)
            {
                if (checkObj.tag == "hand2")
                {
                    hand_state = 1;
                    guard_state = 0;
                    body_state = 0;
                }
                else if (checkObj.tag == "guard2" && hand_state != 1)
                {
                    guard_state = 1;
                    body_state = 0;
                }
                else if (checkObj.tag == "body2" && hand_state != 1 && guard_state != 1)
                {
                    body_state = 1;
                }
            }
        }
        if (hand_state == 1)
        {
            hand_count += 1;
            Debug.Log("hand");
            start_time = Time.time;
            hand_state = 0;
            colList.Clear();
            Instantiate(guardPrefab, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(this.guardSE);
        }
        else if (guard_state == 1)
        {
            guard_count += 1;
            Debug.Log("guard");
            start_time = Time.time;
            guard_state = 0;
            colList.Clear();
            guardsuccess_state1 = 1;
            Instantiate(guardPrefab, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(this.guardSE);
        }
        else if (body_state == 1)
        {
            body_count += 1;
            Debug.Log("body");
            start_time = Time.time;
            body_state = 0;
            colList.Clear();
            damege_state1 = 1;
            if (GameDirector.rage_state1 == 1)
            {
                Instantiate(ragePrefab, transform.position, Quaternion.identity);
                GetComponent<AudioSource>().PlayOneShot(this.rageSE);
            }
            else
            {
                Instantiate(hitPrefab, transform.position, Quaternion.identity);
                int dice = Random.Range(1, 4);
                if (dice == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(this.hitSE1);
                }
                else if (dice == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(this.hitSE2);
                }
                else
                {
                    GetComponent<AudioSource>().PlayOneShot(this.hitSE3);
                }
            }
        }
    }
}
