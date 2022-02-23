using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    public float mouseSensitivity = 100f;
    public PointsManager pointsManager;
    public HealthManager healthManager;
    public MainSceneCoordinator coordinator;
    float margin = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        applyMovement();
        mouseLook();
    }

    void applyMovement()
    {
        float horizontalDelta = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalDelta = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(horizontalDelta, 0, verticalDelta);
        applyAnimations(horizontalDelta, verticalDelta);
        isAiming();
    }

    void isAiming()
    {
        if (Input.GetMouseButtonDown(1))
        {
            coordinator.SetBool("aiming", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            coordinator.SetBool("aiming", false);
        }

    }

    void applyAnimations(float horizontalDelta, float verticalDelta)
    {
        if (verticalDelta >= margin)
        {
            coordinator.setState(MainSceneCoordinator.State.Walking);
        }
        else if (verticalDelta <= -margin)
        {
            coordinator.setState(MainSceneCoordinator.State.WalkingBackwards);
        }
        else
        {
            if (horizontalDelta >= margin)
            {
                coordinator.setState(MainSceneCoordinator.State.StrafeRight);
            }
            else if (horizontalDelta <= -margin)
            {
                coordinator.setState(MainSceneCoordinator.State.StrafeLeft);

            }
            else
            {
                coordinator.setState(MainSceneCoordinator.State.Idle);

            }

        }
    }
    void mouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        // float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
    private void OnCollisionEnter(Collision collison)
    {
        Debug.Log(collison.gameObject.tag + " collision");
        if (collison.gameObject.tag == "Ocean")
        {

            pointsManager.onGetCoin();
            healthManager.onReceiveAttack(9999);
        }

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Point")
        {
            Destroy(collider.gameObject);
            pointsManager.onGetCoin();
            healthManager.onReceiveAttack(10);
        }
        Debug.Log(collider.gameObject.tag);

    }
}
