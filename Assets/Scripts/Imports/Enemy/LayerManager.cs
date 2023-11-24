using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    public List<GameObject> Enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TurnLayer()
    {
        foreach (var enemy in Enemies)
        {
            enemy.gameObject.GetComponent<EnemyScript>().TurnAround(false);
        }
    }
}
