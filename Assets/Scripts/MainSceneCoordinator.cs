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
        WalkingBackwards,
        StrafeRight,
        StrafeLeft,
        Aiming
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBool(string name, bool value)
    {
        anim.SetBool(name, value);
    }
    public void setState(State state)
    {

        if (state == State.Walking)
        {
            anim.SetBool("walking", true);
            anim.SetBool("walkingBackwards", false);
            anim.SetBool("strafeLeft", false);
            anim.SetBool("strafeRight", false);
        }
        else if (state == State.Idle)
        {
            anim.SetBool("walking", false);
            anim.SetBool("walkingBackwards", false);
            anim.SetBool("strafeLeft", false);
            anim.SetBool("strafeRight", false);
        }
        else if (state == State.WalkingBackwards)
        {
            anim.SetBool("walking", false);
            anim.SetBool("walkingBackwards", true);
            anim.SetBool("strafeLeft", false);
            anim.SetBool("strafeRight", false);
        }
        else if (state == State.StrafeRight)
        {
            anim.SetBool("walking", false);
            anim.SetBool("walkingBackwards", false);
            anim.SetBool("strafeLeft", false);
            anim.SetBool("strafeRight", true);

        }
        else if (state == State.StrafeLeft)
        {
            anim.SetBool("walking", false);
            anim.SetBool("walkingBackwards", false);
            anim.SetBool("strafeLeft", true);
            anim.SetBool("strafeRight", false);
        }

    }
}