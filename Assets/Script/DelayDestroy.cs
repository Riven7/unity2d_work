using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayDestroy : MonoBehaviour
{
    public bool destroyOnAwake = true;
    public float awakeDestroyDelay;

    // Start is called before the first frame update
    void Awake()
    {
        if (destroyOnAwake)
        {
            Destroy(gameObject, awakeDestroyDelay);// 销毁爆炸圆
        }
    }
}
