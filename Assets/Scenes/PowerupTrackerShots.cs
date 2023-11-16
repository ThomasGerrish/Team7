using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupTrackerShots : MonoBehaviour

{
    public float fallSpeed = 5.0f;
    public float boostDuration = 15f; // Duration of the homing ability

    void Update()
    {
        // Move the power-up down
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ApplyHomingBullets(other.gameObject));
            Destroy(gameObject); // Destroy the power-up after applying the effect
        }
    }

    IEnumerator ApplyHomingBullets(GameObject player)
    {
        PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();

        if (playerShooting != null)
        {
            playerShooting.EnableHomingBullets();

            yield return new WaitForSeconds(boostDuration);

            playerShooting.DisableHomingBullets();
        }
    }
}


/* BEN -
 * Add this to the shooting script 
 * 
 * public class PlayerShooting : MonoBehaviour
{
    // Existing variables and methods

    public void EnableHomingBullets()
    {
        // Enable homing bullets
    }

    public void DisableHomingBullets()
    {
        // Disable homing bullets
    }

    // Other methods and logic
}
---------------------------------------------------------
Add this to the Bullet Script - 

public class HomingBullet : MonoBehaviour
{
    public float speed = 5f;
    public float rotateSpeed = 200f;
    private Transform target;

    void Start()
    {
        // Find the closest enemy
        target = FindClosestEnemy();
    }

    void Update()
    {
        if (target == null) return;

        Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    Transform FindClosestEnemy()
    {
        // Implement logic to find the closest enemy
    }
}
