using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float defSpeed = 5;
    public bool canShoot = true;
    public int bulletCycle = 1;
    public GameObject Bullet1, Bullet2, Bullet3;
    public float movement;
    bool shooting;
    float speed, speedUpTimer, speedUpTimerDef;
    public bool barrierUp;
    // Start is called before the first frame update
    void Start()
    {
        // Maximum movement x is 6.26772
    }

    // Update is called once per frame
    void Update()
    {
        // Speed Powerup
        speedUpTimer -= Time.deltaTime;
        if (speedUpTimer > 0) speed = 7.5f;
        else speed = defSpeed;


        // Movement
        movement = Input.GetAxis("Horizontal");

        transform.Translate(movement * speed * Time.deltaTime, 0, 0);
        if (transform.position.x >= 6.26772f) transform.position = new Vector2(6.26772f, transform.position.y);
        if (transform.position.x <= -6.26772f) transform.position = new Vector2(-6.26772f, transform.position.y);

        // Shooting
        if (Input.GetKey(KeyCode.Space)) shooting = true;
        else shooting = false;
        if (shooting && canShoot)
        {
            canShoot = false;

            if (bulletCycle == 1)
            {
                Bullet1.GetComponent<BulletScript>().ShootTrigger();
                bulletCycle++;
            }
            else if (bulletCycle == 2)
            {
                Bullet2.GetComponent<BulletScript>().ShootTrigger();
                bulletCycle++;
            }
            else if (bulletCycle == 3)
            {
                Bullet3.GetComponent<BulletScript>().ShootTrigger();
                bulletCycle = 1;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Speed Up")
        {
            speedUpTimer = speedUpTimerDef;
        }
        if (other.gameObject.name == "Barrier Up")
        {
            barrierUp = true;
            GetComponent<BarrierScript>().Damage();
        }
    }

    public void BulletHit()
    {
        canShoot = true;
    }

    public void Damage()
    {

    }

    public void GameOver()
    {

    }
}
