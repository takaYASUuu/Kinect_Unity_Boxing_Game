using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    float maxHp1 = 100.0f;
    float currentHp1;
    float maxHp2 = 100.0f;
    float currentHp2;
    public Slider slider1;
    public Slider slider2;
    int pre_attack1_value;
    int pre_attack2_value;
    int attack2_value = 100;
    int attack1_value = 100;
    int attack_rise_value = 20;
    public static int rage_state1 = 0;
    bool rage_mode1 = false;
    public static int rage_state2 = 0;
    bool rage_mode2 = false;
    GameObject attack1_value_text;
    GameObject attack2_value_text;
    GameObject title;
    public AudioClip Round1SE;
    public AudioClip FightSE;
    public AudioClip FinishSE;
    int finish_state = 0;
    Color pre_colar;

    // Start is called before the first frame update
    void Start()
    {
        this.attack1_value_text = GameObject.Find("Attack1_value_text");
        this.attack2_value_text = GameObject.Find("Attack2_value_text");
        this.title = GameObject.Find("title");
        GetComponent<AudioSource>().PlayOneShot(this.Round1SE);
        Invoke("Fight", 1.5f);
        slider1.value = 1;
        slider2.value = 1;
        currentHp2 = maxHp2;
        currentHp1 = maxHp1;
        pre_colar = this.attack1_value_text.GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (battle.guardsuccess_state1 == 1)
        {
            attack2_value += attack_rise_value;
            this.attack2_value_text.GetComponent<Text>().text = attack2_value.ToString("D3") + "%";
            battle.guardsuccess_state1 = 0;
            if (rage_state1 == 1)
            {
                rage_state1 = 0;
                attack1_value = pre_attack1_value;
                this.attack1_value_text.GetComponent<Text>().text = attack1_value.ToString("D3") + "%";
                this.attack1_value_text.GetComponent<Text>().color = pre_colar;
            }
        }
        float damege1 = 3.0f * (float)attack1_value/100.0f;
        if (battle.damege_state1 == 1)
        {
            currentHp2 -= damege1;
            slider1.value = currentHp2 / maxHp2;
            battle.damege_state1 = 0;
            if (rage_state1 == 1)
            {
                rage_state1 = 0;
                attack1_value = pre_attack1_value;
                this.attack1_value_text.GetComponent<Text>().text = attack1_value.ToString("D3") + "%";
                this.attack1_value_text.GetComponent<Text>().color = pre_colar;
            }
        }
        if (currentHp1/maxHp1 <= 0.25 && rage_mode1 == false)
        {
            rage_state1 = 1;
            rage_mode1 = true;
            pre_attack1_value = attack1_value;
            attack1_value = 1000;
            this.attack1_value_text.GetComponent<Text>().text = attack1_value.ToString("D3") + "%";
            this.attack1_value_text.GetComponent<Text>().color = new Color(1, 0, 0, 1);
        }
        if (battle2.guardsuccess_state2 == 1)
        {
            attack1_value += attack_rise_value;
            this.attack1_value_text.GetComponent<Text>().text = attack1_value.ToString("D3") + "%";
            battle2.guardsuccess_state2 = 0;
            if (rage_state2 == 1)
            {
                rage_state2 = 0;
                attack2_value = pre_attack2_value;
                this.attack2_value_text.GetComponent<Text>().text = attack2_value.ToString("D3") + "%";
                this.attack2_value_text.GetComponent<Text>().color = pre_colar;
            }
        }
        float damege2 = 3.0f * (float)attack2_value / 100.0f;
        if (battle2.damege_state2 == 1)
        {
            currentHp1 -= damege2;
            slider2.value = currentHp1 / maxHp1;
            battle2.damege_state2 = 0;
            if (rage_state2 == 1)
            {
                rage_state2 = 0;
                attack2_value = pre_attack2_value;
                this.attack2_value_text.GetComponent<Text>().text = attack2_value.ToString("D3") + "%";
                this.attack2_value_text.GetComponent<Text>().color = pre_colar;
            }
        }
        if (currentHp2 / maxHp2 <= 0.25 && rage_mode2 == false)
        {
            rage_state2 = 1;
            rage_mode2 = true;
            pre_attack2_value = attack2_value;
            attack2_value = 1000;
            this.attack2_value_text.GetComponent<Text>().text = attack2_value.ToString("D3") + "%";
            this.attack2_value_text.GetComponent<Text>().color = new Color(1, 0, 0, 1);
        }
        if (currentHp1 <= 0 && finish_state == 0)
        {
            finish_state = 1;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(this.FinishSE);
            this.title.GetComponent<Text>().text = "2P Win";
        }
        else if (currentHp2 <= 0 && finish_state == 0)
        {
            finish_state = 1;
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(this.FinishSE);
            this.title.GetComponent<Text>().text = "1P Win";
        }
    }

    void Fight()
    {
        this.title.GetComponent<Text>().text = "Fight!!";
        GetComponent<AudioSource>().PlayOneShot(this.FightSE);
        Invoke("clear_title", 1.0f);
        Invoke("BGM", 1.0f);
    }

    void clear_title()
    {
        this.title.GetComponent<Text>().text = "";
    }
    void BGM()
    {
        GetComponent<AudioSource>().Play();
    }
}
