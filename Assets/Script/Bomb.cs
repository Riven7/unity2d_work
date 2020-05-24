using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float bombRadius = 5f;  // 杀伤范围
    public float bombForce = 100f;  // 冲击力
    public float fuseTime = 1.5F;   // 引线时间
    public GameObject explosion;    // 爆炸背景圆

    private LayBombs layBombs;              //放置炸弹脚本
    private PickupSpawner pickupSpawner;    // 道具生成脚本，启动新协程用
    private ParticleSystem explosionFX;     // 爆炸粒子效果

    void Awake()
    {
        explosionFX = GameObject.FindGameObjectWithTag("ExplosionFX").GetComponent<ParticleSystem>();
        pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
        layBombs = GameObject.FindGameObjectWithTag("Player").GetComponent<LayBombs>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (transform.root == transform)    //没有降落伞

            StartCoroutine(BombDetonation());
    }

    IEnumerator BombDetonation()
    {
        yield return new WaitForSeconds(fuseTime);
        Explode();
    }

    public void Explode()
    {
        layBombs.bombLaid = false; // Hero可再次释放Bomb

        pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());// 启动产生新道具协程

        // 在杀伤范围内查找敌人,,圆形内进行射线检测
        int nLayer = 1 << LayerMask.NameToLayer("Enemy");
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, bombRadius, nLayer);

        foreach (Collider2D en in enemies)
        {
            Rigidbody2D enemyBody = en.GetComponent<Rigidbody2D>();
            if (enemyBody != null && enemyBody.tag == "Enemy")
            {
                enemyBody.gameObject.GetComponent<Enemy>().HP = 0;//让敌人死亡
                Vector3 deltaPos = enemyBody.transform.position - transform.position;

                //normalized保持向量的方向不变，使其长度为1
                Vector3 force = deltaPos.normalized * bombForce;
                enemyBody.AddForce(force);      //把敌人炸开
            }
        }

        // 播放爆炸后粒子效果
        explosionFX.transform.position = transform.position;
        explosionFX.Play();

        // 实列化爆炸背景圆
        Instantiate(explosion, transform.position, Quaternion.identity);
        // 销毁Bomb
        Destroy(transform.gameObject);
    }
}


