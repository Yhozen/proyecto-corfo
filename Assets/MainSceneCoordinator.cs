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
        WalkingBackwards
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
            anim.SetBool("walkingBackwards", false);


        }
        else if (state == State.Idle)
        {
            anim.SetBool("walking", false);
            anim.SetBool("walkingBackwards", false);


        }
        else if (state == State.WalkingBackwards)
        {
            anim.SetBool("walking", false);
            anim.SetBool("walkingBackwards", true);

        }
    }
}
