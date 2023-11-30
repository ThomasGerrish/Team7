using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterProjectile : MonoBehaviour
{
    //public GameObject player;
    [Header("Projectile properties")]
    public GameObject projectileBody;
    [SerializeField] float speed;
    public float damage;
    public bool bulletActive;

    [Header("Owner management")]
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
    public void ShootProjectile(GameObject shooter, int projectileType)
    {
        projectileBody.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1f,1f);
        //standard bullet
        if (projectileType == 1)
        {
            projectileBody.transform.localPosition = shooter.transform.position;
            if (isPlayer)
            {
                speed = 4f;
                projectileBody.transform.tag = "Projectile";

            }
            else
            {
                speed = -4f;
                projectileBody.transform.tag = "E_Projectile";
            }
            damage = 1;
            bulletActive = true;
        }
        //heavy bullet (double damage)
        else if(projectileType == 2)
        {
            if (isPlayer)
            {
                speed = 2f;
                projectileBody.transform.tag = "Projectile";
            }
            else
            {
                speed = -2;
                projectileBody.transform.tag = "E_Projectile";

            }
            damage = 2;
        }
        //light bullet (fast travel)
        else if(projectileType ==3)
        {
 
            projectileBody.transform.localPosition = shooter.transform.position;
            if (isPlayer)
            {
                speed = 6f;
                projectileBody.transform.tag = "Projectile";
            }
            else
            {
                speed = -6f;
                projectileBody.transform.tag = "E_Projectile";
            }
            damage = 0.5f;
            bulletActive = true;
        }
        else if (projectileType == 4)
        {

            projectileBody.transform.localPosition = shooter.transform.position;
            if(isPlayer)
            {
                speed = 4f;
                projectileBody.transform.tag = "Explosive";
            }
            damage = 1f;
            bulletActive = true;
        }
    }
    public void ExplodeBullet()
    {
        projectileBody.tag = "Exploded";
        projectileBody.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(20f,10f);
        StartCoroutine(ExplosionTime(.05f));
    }
    IEnumerator ExplosionTime(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        DisableBullet();
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
