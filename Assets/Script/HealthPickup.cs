﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private float healthBonus = 10f;       //一次加多少血
    private PickupSpawner pickupSpawner;
    private Animator anim;
    private bool landed = false;    //false代表未着陆

    void Awake()
    {
        anim = transform.root.GetComponent<Animator>();
        pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 半空中被接着or在地上被英雄捡取后
        if (other.tag == "Player")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            playerHealth.health += healthBonus; //加血
            if (playerHealth.health > 100)
                playerHealth.health = 100;

            //更新血条
            playerHealth.UpDateHealthBar();

            //开启新协程
            pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());

            //销毁医疗包
            Destroy(transform.root.gameObject);
        }
        //落在地面
        else if (other.tag == "ground" && !landed)
        {
            anim.SetTrigger("Land");
            transform.parent = null;
            gameObject.AddComponent<Rigidbody2D>();
            landed = true;
        }
        /*应该是触发完一次后就停了，当有再一次新的触发时可再执行这个函数
        这样英雄便可以去捡医疗包*/
    }
}
