using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosion;

    private Enemy enemy;
    private Enemy2 enemy2;

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
        if (collision.tag != "Player")
        {
            OnExplode();
            Destroy(gameObject);
        }

        if (collision.tag == "Enemy")
        {
            //enemys = collision.GetComponent<Enemy>();
            //enemys.Hurt();

            //if (collision.GetComponent<Enemy>() == true)也正确
            if (enemy = collision.gameObject.GetComponent<Enemy>())
            {
                //enemy = collision.GetComponent<Enemy>();
                enemy.Hurt();
            }
            //else if (collision.GetComponent<Enemy2>() == true)也正确
            else if (enemy2 = collision.GetComponent<Enemy2>())
            {
                //enemy2 = collision.GetComponent<Enemy2>();
                enemy2.Hurt();
            }
        }     
    }
}