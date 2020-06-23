using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private float healthBonus = 10f;       //一次加多少血
    private PickupSpawner pickupSpawner;
    private Animator anim;
    private bool landed = false;    //false代表未着陆
    private AudioSource audio1;

    void Awake()
    {
        anim = transform.root.GetComponent<Animator>();
        pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
        // 捡到炸弹包的音源放在pickupManager上
        audio1 = GameObject.Find("pickupManager").GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 半空中被接着or在地上被英雄捡取后
        if (other.tag == "Player")
        {
            if (audio1 != null)  //  播放捡到医疗包声音
            {
                if (!audio1.isPlaying)
                {
                    audio1.Play();
                }
            }

            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            playerHealth.health += healthBonus; //加血
            if (playerHealth.health > 100)
                playerHealth.health = 100;

            //更新血条
            playerHealth.UpDateHealthBar(0.10f);

            //开启新协程
            pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());

            //销毁医疗包
            Destroy(transform.root.gameObject);
        }
        //落在地面
        else if (other.tag == "ground" && !landed)
        {
            anim.SetTrigger("Land");
            transform.parent = null;    //此时并没有销毁父物体
            gameObject.AddComponent<Rigidbody2D>();
            landed = true;
        }
        /*应该是触发完一次后就停了，当有再一次新的触发时可再执行这个函数
        这样英雄便可以去捡医疗包*/
    }
}
