using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Player will die
        }
    }
}
