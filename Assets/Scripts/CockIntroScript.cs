using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CockIntroScript : MonoBehaviour
{
    // private float _timer = 0f;

    private void Awake()
    {
        StartCoroutine(WaitAndLoadMainMenu());
    }

    private IEnumerator WaitAndLoadMainMenu()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene("MainMenu");
    }

    /*
    private void FixedUpdate()
    {
        _timer += Time.deltaTime;

        if (_timer >= 7f)
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }
    }
    */
}
