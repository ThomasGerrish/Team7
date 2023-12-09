using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] float currentTime;
    [SerializeField] float startingTime;
    [SerializeField] TextMeshProUGUI timerDisplay;
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
            timerDisplay.text = "0:" + currentTime.ToString("0");
        }
        else if(currentTime <= 0)
        {
            currentTime = 0f;
        }
    }
}
