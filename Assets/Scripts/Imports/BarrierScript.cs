using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    GameObject Player;
    float health = 4;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<PlayerScript>().barrierUp)
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            ShooterProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<ShooterProjectile>();
            Damage(hitprojectile.damage);
            hitprojectile.DisableBullet();
        }
        else if (collision.gameObject.tag == "E_Projectile")
        {
            ShooterProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<ShooterProjectile>();
            Damage(hitprojectile.damage);
            hitprojectile.DisableBullet();
        }
        else if (collision.gameObject.tag == "Explosive")
        {
            ShooterProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<ShooterProjectile>();
            Damage(hitprojectile.damage);
            hitprojectile.ExplodeBullet();
        }
        else if (collision.gameObject.tag == "Exploded")
        {
            ShooterProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<ShooterProjectile>();
            Damage(hitprojectile.damage / 2f);
        }
    }
    public void Damage(float damage)
    {
        health-=damage;
        if (health == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
