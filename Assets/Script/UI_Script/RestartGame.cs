using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    private Button startGame;

    private void Awake()
    {
        startGame = GetComponent<Button>();
    }

    public void OnBtnClick()
    {
        SceneManager.LoadScene(0);
    }
}
