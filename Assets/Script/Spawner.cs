using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnTime = 3f;
    public float spawnDelay = 3f;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        //重复激发函数（在spawnDelay时间后开始执行Spawn函数，每隔spawnTime执行一次）
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
