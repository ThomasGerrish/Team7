using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy properties")]
    public bool alive;
    [SerializeField] float HP;
    [SerializeField] float moveSpeed;
    [SerializeField] float scorePoints;
    [SerializeField] LayerManager myManager;

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

    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
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

    public void SpawnMe(Sprite mySprite, float speed)
    {
        alive = true;
        moveSpeed = speed;
        myRenderer.sprite = mySprite;
        gameObject.transform.localPosition = mySpawn;
        myCollider.enabled = true;
        myRenderer.enabled = true;
        //gameObject.transform.localScale = myScale;
        //myManager.activeEnemies++;
    }

    // Hitbox properties
    void OnDamage(float damage)
    {
        HP = HP - damage;
        if(HP <= 0)
        {
            myManager.activeEnemies--;
            alive = false;
            myRenderer.enabled = false;
            myCollider.enabled = false;
            if(myManager.activeEnemies == 0)
            {
                myManager.ClearLayer();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            ShooterProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<ShooterProjectile>();
            OnDamage(hitprojectile.damage);
            hitprojectile.DisableBullet();
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
