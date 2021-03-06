﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    public GameObject splash;
    public PlayerHealth subHealth;

    private bool playerDeath = false;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.tag == "Player")
        {
            //禁掉摄像机跟随主角的功能，防止主角销毁后摄像机找不到主角出bug
            //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;
            Camera.main.GetComponent<CameraFollow>().enabled = false;

            //使英雄血条功能失效但不销毁,可使血条不可见，也防止找销毁后的主角出bug
            if (GameObject.Find("UI_HealthDisplay").activeSelf)
                GameObject.Find("UI_HealthDisplay").SetActive(false);
            //也可销毁血条，但可能存在血条销毁但hero销毁前hero碰到了敌人会减血出bug

            subHealth.GameOver();
        }
        else if (collison.gameObject.tag == "Enemy")
        {
            Collider2D c = collison.gameObject.GetComponent<Collider2D>();
            if (c.isTrigger == false)
            {
                if (subHealth.health > 0)
                {
                    subHealth.health -= 10f;
                    subHealth.AudioPlay();
                    subHealth.UpDateHealthBar(-0.10f);
                    Debug.Log("sub10");
                }
                if (subHealth.health <= 0 && playerDeath == false)
                {
                    subHealth.Death();
                    playerDeath = true;
                }
            }
        }
        Instantiate(splash, collison.transform.position, transform.rotation);
        //Debug.Log(splash.transform.position.z);
        Destroy(collison.gameObject);

    }
}
