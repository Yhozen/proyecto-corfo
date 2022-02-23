using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").GetLength(0);
        zombieCount.text = $"Zombies remaining: {enemyCount}";

    }
}
