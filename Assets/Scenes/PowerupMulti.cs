using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMulti: MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public float boostDuration = 15f; // Duration of the new shooting pattern

    void Update()
    {
        // Move the power-up down
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the power-up collides with the player
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ApplyMultiDirectionalShooting(other.gameObject));
            Destroy(gameObject); // Destroy the power-up after applying the effect
        }
    }

    IEnumerator ApplyMultiDirectionalShooting(GameObject player)
    {
        PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();

        if (playerShooting != null)
        {
            // Enable multi-directional shooting
            playerShooting.EnableMultiDirectionalShooting();

            // Wait for the boost duration
            yield return new WaitForSeconds(boostDuration);

            // Revert to the original shooting pattern
            playerShooting.DisableMultiDirectionalShooting();
        }
    }
}

/* - MESSAGE FOR BEN -- 
 * Please add this to the shooting script 

public class PlayerShooting : MonoBehaviour
{
    // Existing variables and methods

    public void EnableMultiDirectionalShooting()
    {
        // Code to change the shooting pattern
        // Fire one bullet upwards and two bullets at 45 degrees left and right
    }

    public void DisableMultiDirectionalShooting()
    {
        // Code to revert back to the normal shooting pattern
    }

    // Other methods and logic
}
