using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseCanvas;
    [SerializeField] GameObject GameOverCanvas;
    public bool paused;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            PauseGame();
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        PauseCanvas.SetActive(true);
        paused = true;
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverCanvas.SetActive(true);
        paused = true;
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        PauseCanvas.SetActive(false);
        paused = false;
    }
    public void ReloadScene()
    {
        string curent = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(curent);
    }
    public void QuitToStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
