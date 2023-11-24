using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Enemy properties")]
    [SerializeField] float HP;
    [SerializeField] float moveSpeed;
    [SerializeField] float scorePoints;

    [Header("Custom properties")]
    public bool itemDrop;
    [SerializeField] GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        LayerManager myLayer = gameObject.transform.parent.GetComponent<LayerManager>();
        myLayer.Enemies.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(moveSpeed * Time.deltaTime,0, 0);
    }
    //Movement
    public void TurnAround(bool descend)
    {
        if (!descend)
        {
            moveSpeed = moveSpeed * -1;
        }
    }

    // Hitbox properties
    void OnDamage(float damage)
    {
        HP = HP - damage;
        if(HP <= 0)
        {
            LayerManager myLayer = gameObject.transform.parent.GetComponent<LayerManager>();
            myLayer.Enemies.Remove(gameObject);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            PlayerProjectile hitprojectile = collision.gameObject.transform.parent.gameObject.GetComponent<PlayerProjectile>();
            OnDamage(hitprojectile.damage);
            hitprojectile.bulletActive = false;
        }
    }
}
