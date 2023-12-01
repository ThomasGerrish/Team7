using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [Header("Enemy properties")]
    public List<GameObject> Enemies;
    [SerializeField] List<int> activeEnemyIndex;
    [SerializeField] List<Sprite> EnemySprites;
    [SerializeField] Vector3 spawnPos;

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
    public float shiftDownRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = gameObject.transform.position;
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
                nextFire = Random.Range(minTime, maxTime);
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
                /*
                int i = 0;

                foreach(var enemy in Enemies)
                {
                    if (!enemy.GetComponent<EnemyScript>().alive)
                    {
                        activeEnemyIndex.Remove(i);
                    }
                    i++;
                }
                */
                int chosenEnemy = Random.Range(0, activeEnemyIndex.Count - 1);


                //Search for available shooter
                int chosenShooter;
                int i = 0;
                foreach (var shooter in Projectiles)
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
    IEnumerator ShiftDown()
    {
        while (activeEnemies != 0)
        {
            yield return new WaitForSeconds(shiftDownRate);
            gameObject.transform.position = new Vector3(0, gameObject.transform.position.y - .2f, 0);
            if(gameObject.transform.position.y <= -3f)
            {
                FindObjectOfType<IngameMenu>().GameOver();
            }

        }
    }
    public void RefreshLifeList()
    {
        int i = 0;
        foreach (var enemy in Enemies)
        {
            if (!enemy.GetComponent<EnemyScript>().alive)
            {
                activeEnemyIndex.Remove(i);
            }
            i++;
        }
    }
    public void ClearLayer()
    {
        layerActive = false;
        myController.CheckForEnd();
    }
    public void Reload()
    {
        gameObject.transform.position = spawnPos;
        activeEnemies = 9;
        activeEnemyIndex.Clear();
        for (int i = 0; i < 9; i++)
        {
            activeEnemyIndex.Add(i);
        }
        layerActive = true;
    }
    public void SpawnEnemy(int slot, int sprite, float speed)
    {
        Enemies[slot].GetComponent<EnemyScript>().SpawnMe(EnemySprites[sprite], speed, sprite);
    }
    public void CooldownFunc()
    {
        StartCoroutine(WaveCooldown());
    }
    IEnumerator WaveCooldown()
    {
        foreach(var enemy in Enemies)
        {
            enemy.GetComponent<EnemyScript>().immortal = true;
        }
        yield return new WaitForSeconds(1f);
        foreach (var enemy in Enemies)
        {
            enemy.GetComponent<EnemyScript>().immortal = false;
        }
        //continue normal process?
        bool allBlanks = true;
        foreach (var enemy in Enemies)
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
        if (shiftDownRate != 0)
        {
            StartCoroutine(ShiftDown());
        }

    }
}

