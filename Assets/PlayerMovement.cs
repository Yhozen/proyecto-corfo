using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 10f;
    public float mouseSensitivity = 100f;
    public PointsManager pointsManager;
    public HealthManager healthManager;

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
