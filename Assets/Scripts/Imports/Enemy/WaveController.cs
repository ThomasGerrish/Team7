using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [SerializeField] List<PatternBase> combos;
    [SerializeField] List<LayerManager> myLayers;
    // Start is called before the first frame update
    void Start()
    {
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
            foreach(var layers in myLayers)
            {
                int pattern = Random.Range(0, combos.Count);
                layers.Reload();
                for (int j = 0; j < 9; j++)
                {
                    layers.SpawnEnemy(j, combos[pattern].pattern[j], 4f);
                }


            }
        }
    }
}
