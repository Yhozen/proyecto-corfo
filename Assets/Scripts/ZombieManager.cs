using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerBody;
    private float LastShoot = 0f;
    void Start()
    {

    }

    void Shoot()
    {
        Debug.Log("attacking");
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerBody == null) return;



        float distance = Vector3.Distance(PlayerBody.transform.position, transform.position);

        if (distance < 1.36f && Time.time > LastShoot + 0.8f)
        {
            Shoot();
            LastShoot = Time.time;
        }
        else
        {
            transform.LookAt(PlayerBody.transform);

        }
    }
}
