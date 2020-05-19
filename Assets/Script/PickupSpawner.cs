using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] pickups;            // 道具数组：炸弹、医疗包
    public float pickupDeliveryTime = 4f;   //产生每种道具间隔时间
    public float dropRangeLeft = -15f;       //最左侧
    public float dropRangeRight = 15f;       // 最右侧
    public float highHealthThreshold = 80f; // 血量大于多少时只产生炸弹包
    public float lowHealthThreshold = 20f;	// 血量低于多少时只产生医疗包

    private PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Start()
    {
        //启动第一次道具产生
        StartCoroutine(DeliverPickup());
    }
    
    //协程
    public IEnumerator DeliverPickup()
    {
        // 第一次时间间隔
        yield return new WaitForSeconds(pickupDeliveryTime);

        // 在最左和最右之间产生随机x值
        float dropPosX = Random.Range(dropRangeLeft, dropRangeRight);
        Vector3 dropPos = new Vector3(dropPosX, 15f, 1f);

        // 只产生炸弹
        if (playerHealth.health >= highHealthThreshold)
            Instantiate(pickups[0], dropPos, Quaternion.identity);
        else if (playerHealth.health <= lowHealthThreshold)
            //只产生医疗包
            Instantiate(pickups[1], dropPos, Quaternion.identity);
        else
        {
            //随机产生炸弹或医疗包
            int pickupIndex = Random.Range(0, pickups.Length);//左闭右开？
            Instantiate(pickups[pickupIndex], dropPos, Quaternion.identity);
        }

    }
}
