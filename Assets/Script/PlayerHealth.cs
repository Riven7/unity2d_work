using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100f;
    public float damageInterval = 0.35f;
    public float hurtForce = 100f;
    public float DamageAmount = 10;

    private SpriteRenderer healthBar;   //血条的精灵渲染
    private float lastHurtTime;     //上次受伤时间
    private Vector3 healthScale;    //血条缩放比例
    private PlayerControl playerControl;    //控制玩家受伤后不能跳
    private Rigidbody2D heroBody;     //碰到一起后给英雄施加力弹开
    
    private void Awake()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        heroBody = GetComponent<Rigidbody2D>();
        playerControl = GetComponent<PlayerControl>();
        healthScale = healthBar.transform.localScale;
    }

    void UpDateHealthBar()
    {
            //颜色从绿到红差值变化，血越少变化越大
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
    }
   void TakeDamage(Transform EnemyTran)
    {
        playerControl.jump = false;
        //得到一个向量，再提供向上的向量Vector3.up = 1
        Vector3 hurtVector3 = transform.position - EnemyTran.position + Vector3.up * 5f;
        heroBody.AddForce(hurtForce * hurtVector3);
        health -= DamageAmount;
        UpDateHealthBar();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Time.time > lastHurtTime + damageInterval)  //当前时间
            {
                if (health > 0)
                {
                    TakeDamage(collision.gameObject.transform); //减血撞开
                    lastHurtTime = Time.time;
                }
                if (health <= 0)
                {
                    Collider2D[] colliders = GetComponents<Collider2D>();    //获取hero所有collision到数组中
                    foreach (Collider2D c in colliders)
                        c.isTrigger = true;     //for循环的另一种用法
                    SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();  //为了把英雄的所有部位的层放在最前面
                    for (int i = 0; i < sprites.Length; i++)
                    {
                        sprites[i].sortingLayerName = "UI";
                    }
                    playerControl.enabled = false;  //让这两个脚本的功能失效
                    GetComponentInChildren<Gun>().enabled = false;
                }
            }
        }
    }
}
