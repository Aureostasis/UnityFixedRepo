using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject sManager;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died!");
        sManager = GameObject.FindGameObjectWithTag("SceneManager");
        // You can add death animation, respawn logic, or game over screen here
        Destroy(gameObject); // Optional: destroy the player on death
        sceneManagerScript sn = sManager.GetComponent<sceneManagerScript>();
        sn.LoadSceneByIndex(0);
    }

    // Optional: Visualize current health in the Inspector
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Player Health: " + currentHealth);
    }
}
