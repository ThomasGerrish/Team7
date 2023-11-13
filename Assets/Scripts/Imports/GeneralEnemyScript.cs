using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemyScript : MonoBehaviour
{
    public GameObject EnemyController;
    // Start is called before the first frame update
    void Start()
    {
        EnemyController = GameObject.Find("Enemy Controller");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            EnemyController.GetComponent<EnemyControllerScript>().Turn();
        }
    }

    public void Damage()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
