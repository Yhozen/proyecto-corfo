using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerBody;
    public float speed = 10f;
    public HealthManager healthManager;

    private float lastAttack = 0f;
    private Animator anim;
    float distance = 99999;
    private int currentHealth;
    public int initialHealth = 100;
    public bool alive = true;
    private AudioSource audioSource;
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = initialHealth;
        audioSource = GetComponent<AudioSource>();

    }

    void Attack()
    {
        anim.SetTrigger("zombieAttack");
        healthManager.onReceiveAttack(5);
    }

    public void onReceiveAttack(int attackDamage)
    {
        currentHealth -= attackDamage;
        if (currentHealth <= 0f)
        {
            anim.SetTrigger("zombieDied");
            alive = false;
            audioSource.Play();
        }
    }
    void walk()
    {
        if (distance > 1.45f)
        {
            Vector3 direction = (transform.position - PlayerBody.transform.position).normalized;
            float horizontalDelta = direction.x * speed * Time.deltaTime * 1.2f / 10f;
            float verticalDelta = direction.z * speed * Time.deltaTime * 1.2f / 10f;

            transform.Translate(horizontalDelta, 0, verticalDelta);
            anim.SetBool("zombieWalking", true);
        }
        else
        {
            anim.SetBool("zombieWalking", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerBody == null) return;

        if (!alive) return;

        distance = Vector3.Distance(PlayerBody.transform.position, transform.position);


        if (distance < 1.5f && Time.time > lastAttack + 2.67f)
        {
            Attack();
            lastAttack = Time.time;
        }
        else
        {
            transform.LookAt(PlayerBody.transform);
        }



        walk();

    }
}
