using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float currentTime;
    [SerializeField] float startingTime;
    [SerializeField] TextMeshProUGUI timerDisplay;
    [SerializeField] IngameMenu myGameManager;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1f * Time.deltaTime;
        }
        else if(currentTime <= 0)
        {
            currentTime = 0f;
            myGameManager.GameOver();
        }
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
