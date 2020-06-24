using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float moveSpeed = 17f;
    public int HP = 1;
    public Sprite deadEnemy;            //死亡后的图片
    public GameObject UI_100Points;     //怪物死亡后的得分
    public float deathSpinMax = 100f;   //怪物死后的旋转量
    public float deathSpinMin = -100f;

    private Transform frontCheck;
    private SpriteRenderer ren;         //负责更换对应的图片
    private Rigidbody2D enemyBody;      //敌人的2D刚体,控制其运动
    private bool bDeath = false;                //true敌人死亡

    private ScoreRank addScore;

    // Start is called before the first frame update
    void Start()
    {
        frontCheck = transform.Find("frontCheck").transform;
        ren = GetComponent<SpriteRenderer>();
        enemyBody = GetComponent<Rigidbody2D>();
        addScore = GameObject.Find("Score").GetComponent<ScoreRank>();
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
        //所以不能将frontCheck放在物体（碰撞体）内部，不然只检测到物体的碰撞体
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
        if (HP == 0 && !bDeath)
            Death();
    }
    void Death()
    {
        bDeath = true;

        SpriteRenderer[] renders = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer s in renders)
            s.enabled = false;
        ren.enabled = true; //在这个怪物上，整个图片是由各部位组成的，上面这四行都必要
        if (deadEnemy != null && ren.enabled == true)
            ren.sprite = deadEnemy;
        //Debug.Log(moveSpeed);
        enemyBody.AddTorque(Random.Range(deathSpinMin, deathSpinMax));
        //给怪物施加随机的旋转量

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
            addScore.AddScore();
        }
        //Destroy(gameObject);
    }
}
