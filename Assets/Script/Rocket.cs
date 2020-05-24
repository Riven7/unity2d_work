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
    }
    void OnExplode()
    {
        Quaternion randRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
        Instantiate(explosion, transform.position, randRotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemys = collision.GetComponent<Enemy>();
        if (collision.tag != "Player")
        {
            OnExplode();
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy")
            enemys.Hurt();     
    }
}