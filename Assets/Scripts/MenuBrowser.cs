using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBrowser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadArcade()
    {
        //SceneManager.LoadScene("Arcade Mode");
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadEndless()
    {
        //SceneManager.LoadScene("Endless Mode");
        SceneManager.LoadScene("SampleScene");
    }
}
