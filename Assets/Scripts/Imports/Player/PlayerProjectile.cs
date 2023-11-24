using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public GameObject player;
    public GameObject projectileBody;
    [SerializeField] float speed;
    public float damage;
    public bool bulletActive;
    //possible projectile limit?
    // Update is called once per frame
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
    public void ShootProjectile()
    {
        projectileBody.transform.localPosition = Vector3.zero;
        bulletActive = true;
    }
}
