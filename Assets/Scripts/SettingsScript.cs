using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        print("Fullscreen mode: " + Screen.fullScreen);
    }

    public void SetSoundVolume()
    {
        AudioListener.volume = GetComponent<Slider>().value;
    }
}
