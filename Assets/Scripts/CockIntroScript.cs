using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CockIntroScript : MonoBehaviour
{
    private float _timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;

        if (_timer >= 7f)
        {
            SceneManager.LoadScene("Scenes/Main Menu");
        }
    }
}
