using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterProjectile : MonoBehaviour
{
    //public GameObject player;
    public GameObject projectileBody;
    [SerializeField] float speed;
    public float damage;
    public bool bulletActive;
    [SerializeField] bool isPlayer;
    [SerializeField] PlayerScript player;
    [SerializeField] LayerManager enemies;
    //possible projectile limit?
    //Update is called once per frame
    void Start()
    {
        if (isPlayer)
        {
            player = FindObjectOfType<PlayerScript>();
        }
        else
        {
            enemies = gameObject.transform.parent.GetComponent<LayerManager>();
        }
    }
    void Update()
    {
        if (bulletActive)
        {
            projectileBody.SetActive(true);
            projectileBody.transform.Translate(0, speed * Time.deltaTime, 0);
        }
        else
        {
            projectileBody.SetActive(false);
        }
    }
    public void ShootProjectile(GameObject shooter, float speed)
    {
        projectileBody.transform.localPosition = shooter.transform.position;
        this.speed = speed;
        bulletActive = true;
    }
    public void DisableBullet()
    {
        bulletActive = false;
        if (isPlayer)
        {
            //bulletcount down
        }
        else
        {
            enemies.bulletCount--;
        }
    }
}
