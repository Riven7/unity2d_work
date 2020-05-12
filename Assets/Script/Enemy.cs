using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 4f;
    public int HP = 2;
    public Sprite deadEnemy;            //死亡后的图片
    public Sprite hurtedEnemy;          //受伤后的图片
    public GameObject UI_100Points;     //怪物死亡后的得分
    public float deathSpinMax = 100f;   //怪物死后的旋转量
    public float deathSpinMin = -100f;

    private Transform frontCheck;
    private SpriteRenderer ren;         //负责更换对应的图片
    private Rigidbody2D enemyBody;      //敌人的2D刚体,控制其运动
    private bool bDeath = false;                //true敌人死亡

    // Start is called before the first frame update
    void Start()
    {
        frontCheck = transform.Find("frontCheck");
        ren = transform.Find("alienShip").GetComponent<SpriteRenderer>();
        enemyBody = GetComponent<Rigidbody2D>();
    }

    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void Hurt()
    {
        HP--;
    }
    private void FixedUpdate()
    {
        int nLayer = 1 << LayerMask.NameToLayer("Wall");
        //在position处检测碰撞，将此处碰撞体返回到frontHits数组中（还可添加两个深度）
        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position, nLayer);
        foreach (Collider2D c in frontHits)
        {
            if (c.tag == "wall")
            {
                flip();     //让enemy转身
                break;
            }
        }
        enemyBody.velocity = new Vector2(moveSpeed * transform.localScale.x, enemyBody.velocity.y);
        if (HP == 1 && hurtedEnemy != null)
            ren.sprite = hurtedEnemy;
        if (HP == 0 && !bDeath)
            Death();
            //ren.sprite = deadEnemy;
    }
    void Death()
    {
        bDeath = true;

        SpriteRenderer[] renders = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in renders)
            s.enabled = false;
        ren.enabled = true; //感觉上面这四行都没必要?
        if (deadEnemy != null)
            ren.sprite = deadEnemy;
        //给怪物施加随机的旋转量
        //enemyBody.AddTorque(Random.Range(deathSpinMin, deathSpinMax));

        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D c in colliders)
            c.isTrigger = true;

        if (UI_100Points != null)
        {
            Vector3 ScorePos;
            ScorePos = transform.position;
            ScorePos.y += 1.6f;
            //Quaternion.identity代表与原图一致，不旋转
            Instantiate(UI_100Points, ScorePos, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
