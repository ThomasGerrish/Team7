using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerupFireRate : MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public float boostDuration = 15f; // Duration of the boost in seconds

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
            StartCoroutine(ApplyFireRateBoost(other.gameObject));
            Destroy(gameObject); // Destroy the power-up after applying the effect
        }
    }

    IEnumerator ApplyFireRateBoost(GameObject player)
    {
        PlayerShooting playerShooting = player.GetComponent<PlayerShooting>();

        if (playerShooting != null)
        {
            // Increase fire rate by 50%
            playerShooting.fireRate *= 0.5f;

            // Wait for the boost duration
            yield return new WaitForSeconds(boostDuration);

            // Revert to the original fire rate
            playerShooting.fireRate /= 0.5f;
        }
    }
}
