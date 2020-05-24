using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPickup : MonoBehaviour
{
    //放在炸弹上的脚本，不含降落伞
    private Animator anim;
    private bool landed = false; //false代表未着陆
    private PickupSpawner pickupSpawner;
    private LayBombs layBombs;

    void Awake()
    {
        anim = transform.root.GetComponent<Animator>();
        pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
        layBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<LayBombs>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //炸弹在空中被接住
        if (other.tag == "Player")
        {
            //销毁炮弹
            Destroy(transform.root.gameObject);
            layBombs.bombCount++;
            //开启新协程
            //pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());
        }
        //掉地上
        else if(other.tag == "ground" && !landed)
        {
            anim.SetTrigger("Land");
            transform.parent = null;
            gameObject.AddComponent<Rigidbody2D>();
            landed = true;
        }
    }
}
