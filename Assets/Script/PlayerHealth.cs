using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float damageInterval = 0.35f;
    public float hurtForce = 100f;
    public float DamageAmount = 10f;
    public AudioClip[] hurtClips;
    public Image healthBar;

    //private SpriteRenderer healthBar;   //血条的精灵渲染
    private float lastHurtTime;     //上次受伤时间
    //private Vector3 healthScale;    //血条缩放比例
    private PlayerControl playerControl;    //控制玩家受伤后不能跳
    private Rigidbody2D heroBody;     //碰到一起后给英雄施加力弹开

    private Animator deathAnim;
    private AudioSource audio1;

    private ScoreRank getScore;
    public GameObject overPanel;
    public ScoreNow sumScore;

    private void Awake()
    {
        //healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        //healthBar = GameObject.FindGameObjectWithTag("healthBar").image;
        heroBody = GetComponent<Rigidbody2D>();
        playerControl = GetComponent<PlayerControl>();
       // healthScale = healthBar.transform.localScale;
        deathAnim = GetComponent<Animator>();
        audio1 = GetComponent<AudioSource>();
        getScore = GameObject.Find("Score").GetComponent<ScoreRank>();
    }

    public void UpDateHealthBar()
    {
            //颜色从绿到红差值变化，血越少变化越大
        healthBar.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        //0.10后必须加f,否则会报错，Cannot implicitly convert type 'double'to 'float'
        healthBar.fillAmount = healthBar.fillAmount - 0.10f;
        //healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        // healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, healthScale.y, healthScale.z);
    }
   void TakeDamage(Transform EnemyTran)
    {
        playerControl.jump = false;
        //得到一个向量，再提供向上的向量Vector3.up = 1
        Vector3 hurtVector3 = transform.position - EnemyTran.position + Vector3.up * 3f;
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
                    deathAnim.SetTrigger("Death");
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

                    overPanel.SetActive(true);
                    sumScore.sumScore(getScore.PlayerScore);
                    getScore.SaveData();

                }
                if (audio1 != null)  //  播放受伤减血声音
                {
                    if (!audio1.isPlaying)
                    {
                        int i = Random.Range(0, hurtClips.Length);
                        audio1.clip = hurtClips[i];
                        audio1.Play();
                        //mixer.SetFloat("hero", 0);
                    }
                }
            }
        }
    }
}
