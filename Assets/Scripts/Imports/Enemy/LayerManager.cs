using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    public List<GameObject> Enemies;
    public List<ShooterProjectile> Projectiles;
    public int maxBulletCount;
    public int bulletCount;
    // Start is called before the first frame update
    void Start()
    {
        if(Projectiles.Count != 0)
        {
            StartCoroutine(ShootingTimer());
        }

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

    IEnumerator ShootingTimer()
    {
        while (true)
        {
            float nextFire = Random.Range(0f, 5f);
            yield return new WaitForSeconds(nextFire);
            if (bulletCount < maxBulletCount)
            {
                Debug.Log(Enemies.Count);
                int chosenEnemy = Random.Range(0, Enemies.Count - 1);
                int chosenShooter;
                int i = 0;
                foreach(var shooter in Projectiles)
                {
                    if (!shooter.bulletActive)
                    {
                        break;
                    }
                    i++;
                }
                chosenShooter = i;
                Projectiles[chosenShooter].ShootProjectile(Enemies[chosenEnemy], -4f);
                bulletCount++;
            }
        }
    }
}

