using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    private float lastShoot = 0f;
    public AudioManager audioManager;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > lastShoot + 0.8f)
        {
            lastShoot = Time.time;
            audioManager.playShoot();
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    ZombieManager zombieManager = hit.transform.gameObject.GetComponent<ZombieManager>();
                    zombieManager.onReceiveAttack(50);
                }
            }
        }

    }
}
