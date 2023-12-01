using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy properties")]
    public bool alive;
    public bool immortal;
    [SerializeField] float HP;
    [SerializeField] float moveSpeed;
    [SerializeField] float scorePoints;
    public int shootingType;

    [Header("References")]
    [SerializeField] LayerManager myManager;
    [SerializeField] PlayerScript myPlayer;

    [Header("Spawn Properties")]
    [SerializeField] Vector3 mySpawn;
    [SerializeField] Vector3 myScale;
    [SerializeField] SpriteRenderer myRenderer;
    [SerializeField] BoxCollider2D myCollider;

    [Header("Custom properties")]
    public bool itemDrop;
    //[SerializeField] GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive && !immortal)
        {
            gameObject.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
    }
    //Movement
    public void TurnAround(bool descend)
    {
        if (!descend)
        {
            moveSpeed = moveSpeed * -1;
        }
    }

    public void SpawnMe(Sprite mySprite, float speed, int type)
    {
        alive = true;
        moveSpeed = speed;
        myRenderer.sprite = mySprite;
        gameObject.transform.localPosition = mySpawn;
        myCollider.enabled = true;
        myRenderer.enabled = true;
        if(type == 0)
        {
            scorePoints = 5;
            HP = 1;
            shootingType = 0;
        }
        else if(type == 1)
        {
            scorePoints = 10;
            HP = 2;
            shootingType = 1;
        }
        else if(type == 2)
        {
            scorePoints = 15;
            HP = 3;
            shootingType = 2;
        }
        else if(type == 3)
        {
            scorePoints = 20;
            HP = 1;
            shootingType = 3;
        }
        else if(type == 4)
        {

        }
        //gameObject.transform.localScale = myScale;
        //myManager.activeEnemies++;
    }

    // Hitbox properties
    void OnDamage(float damage)
    {
        HP = HP - damage;
        if(HP <= 0)
        {
            myPlayer.points += scorePoints;
            myManager.activeEnemies--;
            alive = false;
            myRenderer.enabled = false;
            myCollider.enabled = false;
            myManager.RefreshLifeList();
            if(myManager.activeEnemies == 0)
            {
                myManager.ClearLayer();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!immortal)
        {
            if (collision.gameObject.tag == "Projectile")
            {
                ShooterProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<ShooterProjectile>();
                OnDamage(hitprojectile.damage);
                hitprojectile.DisableBullet();
            }
            else if (collision.gameObject.tag == "Explosive")
            {
                ShooterProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<ShooterProjectile>();
                OnDamage(hitprojectile.damage);
                hitprojectile.ExplodeBullet();
            }
            else if (collision.gameObject.tag == "Exploded")
            {
                ShooterProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<ShooterProjectile>();
                OnDamage(hitprojectile.damage / 2f);
            }
        }
        
    }
    /*
    IEnumerator ShootingTimer()
    {
        while (true)
        {
            float nextFire = Random.Range(0f, 5f);
            yield return new WaitForSeconds(nextFire);
            if (myManager.bulletCount <= myManager.maxBulletCount)
            {
                //firebullet
                myManager.bulletCount++;
            }
        }
    }
    */
}
