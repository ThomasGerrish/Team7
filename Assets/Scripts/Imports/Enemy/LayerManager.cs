using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    public List<GameObject> Enemies;
    [SerializeField] List<int> activeEnemyIndex;
    [SerializeField] List<Sprite> EnemySprites;
    public List<ShooterProjectile> Projectiles;
    public bool layerActive;

    [Header("Level Management")]
    public int activeEnemies;
    public int maxBulletCount;
    public int bulletCount;
    [SerializeField] WaveController myController;

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
        while (activeEnemies != 0)
        {
            float nextFire = Random.Range(0f, 5f);
            yield return new WaitForSeconds(nextFire);
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
                chosenShooter = i;
                Projectiles[chosenShooter].ShootProjectile(Enemies[chosenEnemy], -4f);
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
        StartCoroutine(ShootingTimer());
    }
    public void SpawnEnemy(int slot, int sprite, float speed)
    {
        Enemies[slot].GetComponent<EnemyScript>().SpawnMe(EnemySprites[sprite], speed);
    }
}

