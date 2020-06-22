using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LayBombs : MonoBehaviour
{
    [HideInInspector]
    public bool bombLaid = false;   // 为true代表释放了炸弹
    public GameObject bomb;         //Prefab of the bomb
    public int bombCount = 0;       // Hero有多少个炸弹
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && !bombLaid && bombCount > 0)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                bombCount--;
                bombLaid = true;
                Instantiate(bomb, transform.position, transform.rotation);
            }
        }
    }
}
