using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int initialHealth = 100;
    public int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = initialHealth;

    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    public float getCurrentHealhPercentage()
    {

        return (float)currentHealth / (float)maxHealth * 100f;
    }
    public void onReceiveAttack(int attack)
    {
        currentHealth -= attack;
        currentHealth = Mathf.Max(0, currentHealth);
    }
    public void onReceiveHeal(int heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Min(maxHealth, currentHealth);
    }
}