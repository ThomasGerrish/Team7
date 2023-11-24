using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            PlayerProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<PlayerProjectile>();
            hitprojectile.bulletActive = false;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemycontact");
            collision.gameObject.transform.parent.gameObject.GetComponent<LayerManager>().TurnLayer();
        }
    }
}
