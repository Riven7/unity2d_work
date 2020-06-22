using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    public float speed = 20f;

    private PlayerControl playerCtrl;   // 为了获取hero的朝向

    private AudioSource audio1;     //使用audio会有warning，不懂

    // Start is called before the first frame update
    void Start()
    {
        //playerCtrl = GameObject.Find("hero").GetComponent<PlayerControl>();
        playerCtrl = transform.parent.GetComponent<PlayerControl>();    //找父类的组件
        audio1 = GetComponent<AudioSource>(); //获取声音
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //是为了触发按钮事件时不执行，按钮必须有navigation才行，不能为None
           // EventSystem.current.currentSelectedGameObject == null

            //判断当前事件是否在UGUI物体上面执行，是为true
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                audio1.Play();   //播放声音
                if (playerCtrl.faceRight)
                {
                    // 在position处实例化rocket， Quaternion.Euler new Vector3 控制旋转
                    Rigidbody2D bullet = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    bullet.velocity = new Vector2(speed, 0);
                }
                else
                {
                    Rigidbody2D bullet = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
                    bullet.velocity = new Vector2(-speed, 0);       //z方向旋转180°
                }
            }
        }
    }
}
