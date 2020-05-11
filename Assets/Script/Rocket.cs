﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosion;

    private Enemy enemys;

    void Start()
    {
        Destroy(gameObject, 2);
        enemys = GameObject.Find("Enemy").GetComponent<Enemy>();
    }
    void OnExplode()
    {
        Quaternion randRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        Instantiate(explosion, transform.position, randRotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            OnExplode();
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy")
            enemys.Hurt();      //是否会导致场景中所有Enemy（包括未受炮弹的）都执行此函数？
    }
}