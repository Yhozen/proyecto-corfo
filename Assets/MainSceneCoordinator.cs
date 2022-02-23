using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneCoordinator : MonoBehaviour
{
    public Animator anim;

    public enum State
    {
        Walking,
        Idle,
        High
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setState(State state)
    {
        if (state == State.Walking)
        {
            anim.SetBool("walking", true);

        }
        else if (state == State.Idle)
        {
            anim.SetBool("walking", false);

        }

    }
}
