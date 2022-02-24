using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Debug.Log("matado");
                    ZombieManager zombieManager = hit.transform.gameObject.GetComponent<ZombieManager>();
                    zombieManager.onReceiveAttack(50);
                }
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.red);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10f, Color.green);

            }
        }

    }
}
