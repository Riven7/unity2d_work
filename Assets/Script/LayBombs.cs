using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LayBombs : MonoBehaviour
{
    //[HideInInspector]
    //public bool bombLaid = false;   // 为true代表释放了炸弹
    public GameObject bomb;         //Prefab of the bomb
    public int bombCount = 0;       // Hero有多少个炸弹

    public ShowText countText;

    private float layInterval = 8f;
    private float lastLayTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && bombCount > 0)
        {
            if (!EventSystem.current.IsPointerOverGameObject() && Time.time > lastLayTime + layInterval)
            {
                bombCount--;
                //bombLaid = true;
                Show();
                Instantiate(bomb, transform.position, transform.rotation);
                lastLayTime = Time.time;
            }
        }
    }

    public void Show()
    {
        countText.ShowInt(bombCount);
    }
}
