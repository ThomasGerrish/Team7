using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Player, Gun;
    float speed = 8;
    bool hit;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Gun = GameObject.Find("Gun");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
        hit = false;
    }

    public void ShootTrigger()
    {
        transform.position = new Vector2(Gun.transform.position.x, -4.225f);
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!hit)
        {
            if (other.gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                other.gameObject.GetComponent<GeneralEnemyScript>().Damage();
                Player.GetComponent<PlayerScript>().BulletHit();
                Player.GetComponent<PlayerScript>().PointsUp();
                hit = true;
            }
            if (other.gameObject.tag == "Barrier")
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                other.gameObject.GetComponent<BarrierScript>().Damage();
                Player.GetComponent<PlayerScript>().BulletHit();
                hit = true;
            }
            if (other.gameObject.tag == "Wall")
            {
                Player.GetComponent<PlayerScript>().BulletHit();
            }
        }
    }
}
