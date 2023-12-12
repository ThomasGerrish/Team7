using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveController : MonoBehaviour
{
    [SerializeField] List<PatternBase> combos;
    [SerializeField] List<LayerManager> myLayers;
    [SerializeField] int wave;
    [SerializeField] float waveSpeed;
    [SerializeField] int projectileLimit;
    [SerializeField] float shiftDown;
    [SerializeField] TextMeshProUGUI waves;
    [SerializeField] bool timedMode;
    [SerializeField] TimerScript myTimer;
    // Start is called before the first frame update
    void Start()
    {
        wave = 0;
        CheckForEnd();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckForEnd()
    {
        int i = 0;
        foreach (var layers in myLayers)
        {
            if (!layers.layerActive)
            {
                i++;
            }
        }
        if(i == 5)
        {
            wave++;
            Debug.Log("Updating wave");
            UpdateWave();
            foreach (var layers in myLayers)
            {
                layers.CooldownFunc();
                int pattern = Random.Range(0, combos.Count);
                
                for (int j = 0; j < 9; j++)
                {
                    layers.SpawnEnemy(j, combos[pattern].pattern[j], waveSpeed);
                }
                layers.maxBulletCount = projectileLimit;
                layers.shiftDownRate = shiftDown;

                layers.Reload();
                
            }

        }
    }
    //Difficulty Scaler, debate if want to change
    void UpdateWave()
    {
        if (timedMode)
        {
            myTimer.currentTime += 30f;
        }
        if(waves != null)
        {
            waves.text = "Wave: " + wave.ToString();
        }
        if(wave < 10)
        {
            waveSpeed += .2f;
        }
        else if (wave < 20)
        {
            waveSpeed += .3f;
        }
        else if(wave > 20)
        {
            waveSpeed = 6f;
        }
        if (wave == 5)
        {
            projectileLimit = 2;
        }
        else if( wave == 10)
        {
            shiftDown = 10f;
        }
        else if (wave == 15)
        {
            shiftDown = 7f;
        }
        else if(wave == 20)
        {
            projectileLimit = 3;
            shiftDown = 5f;
        }
    }
}
