using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpBase : MonoBehaviour
{
    public float fallSpeed = 5.0f;

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
            ApplyEffect();
            Destroy(gameObject); // Destroy the power-up after applying the effect
        }
    }

    void ApplyEffect()
    {
        // You can customize this function to apply different effects
        Debug.Log("Power-up collected!");

        // Example: Increase player's speed, add points, etc.
    }
}


/* Attach to Power-Up: Attach this script to your power-up GameObject in Unity.
Customize the Effect: Modify the ApplyEffect method to implement the specific effect you want when the player collects the power-up.
Set the Fall Speed: Adjust the fallSpeed in the inspector to control how fast the power-up falls.
Tag the Player: Ensure your player GameObject has the tag "Player" for the collision detection to work.*/ 