using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ZombieCount : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI zombieCount;
    int enemyCount;

    void Start()
    {
        zombieCount = GetComponent<TextMeshProUGUI>();
        zombieCount.text = "Yeah!";
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = 0;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<ZombieManager>().alive)
            {
                enemyCount++;
            }
        }

        if (enemyCount == 0)
        {
            SceneManager.LoadScene("GameOver");

        }
        zombieCount.text = $"Zombies remaining: {enemyCount}";

    }
}
