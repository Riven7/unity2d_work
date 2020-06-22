using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExitGame : MonoBehaviour
{
    public void OnBtnClick()
    {
        #if UNITY_EDITOR    //判断是否在unity编译里使用，必须使用#if #else #endif的格式
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        //Debug.Log("exit");
    }
}

