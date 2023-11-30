using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [Header("Enemy properties")]
    public List<GameObject> Enemies;
    [SerializeField] List<int> activeEnemyIndex;
    [SerializeField] List<Sprite> EnemySprites;

    [Header("Projectile properties")]
    public List<ShooterProjectile> Projectiles;
    [SerializeField] float maxTime;
    [SerializeField] float minTime;

    [Header("Level Management")]
    public int activeEnemies;
    public int maxBulletCount;
    public int bulletCount;
    [SerializeField] WaveController myController;
    public bool layerActive;

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
            enemy.GetComponent<EnemyScript>().TurnAround(false);
        }
    }
    IEnumerator ShootingTimer()
    {
        Debug.Log("Starting shooting");
        EnemyScript enemyClass;
        bool skipTime = false;
        float nextFire = 0;
        while (activeEnemies != 0)
        {
            if (!skipTime)
            {
                nextFire = Random.Range(minTime,maxTime);
            }
            else
            {
                nextFire = 0f;
            }
            yield return new WaitForSeconds(nextFire);
            skipTime = false;
            if (bulletCount < maxBulletCount)
            {
                //Search for active enemies and choose one
                int i = 0;
                foreach(var enemy in Enemies)
                {
                    if (!enemy.GetComponent<EnemyScript>().alive)
                    {
                        activeEnemyIndex.Remove(i);
                    }
                    i++;
                }
                int chosenEnemy = Random.Range(0, activeEnemyIndex.Count - 1);


                //Search for available shooter
                int chosenShooter;
                i = 0;
                foreach(var shooter in Projectiles)
                {
                    if (!shooter.bulletActive)
                    {
                        break;
                    }
                    i++;
                }
                enemyClass = Enemies[chosenEnemy].GetComponent<EnemyScript>();
                if (enemyClass.shootingType == 0)
                {
                    skipTime = true;
                    continue;
                }
                chosenShooter = i;
                Projectiles[chosenShooter].ShootProjectile(Enemies[chosenEnemy], enemyClass.shootingType);
                bulletCount++;
            }
        }
    }
    public void ClearLayer()
    {
        layerActive = false;
        myController.CheckForEnd();
    }
    public void Reload()
    {
        /*
        foreach(var enemy in Enemies)
        {
            enemy.GetComponent<EnemyScript>().SpawnMe(EnemySprites[0], 4f);
            activeEnemies++;
        }
        */
        activeEnemies = 9;
        activeEnemyIndex.Clear();
        for (int i = 0; i < 10; i++)
        {
            activeEnemyIndex.Add(i);
        }
        layerActive = true;
        bool allBlanks = true;
        foreach(var enemy in Enemies)
        {
            if (enemy.gameObject.GetComponent<EnemyScript>().shootingType != 0)
            {
                allBlanks = false;
            }
        }
        if (!allBlanks)
        {
            StartCoroutine(ShootingTimer());
        }

    }
    public void SpawnEnemy(int slot, int sprite, float speed)
    {
        Enemies[slot].GetComponent<EnemyScript>().SpawnMe(EnemySprites[sprite], speed, sprite);
    }
}

