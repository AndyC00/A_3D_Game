using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //scrolling speed
    public float zoomSpeed = 10f;
    public float rotationSpeed = 100f;

    private Vector3 offset;
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag(Tag.PLAYER).transform;
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        Vector3 targetPosition = playerTransform.position + new Vector3(0, 1.0f, 0); // 1.5f to adjust

        transform.position = targetPosition + offset;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += scroll * zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 37, 70);

        if (Input.GetMouseButton(1)) //right click to change sight
        {
            float rotateHorizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotateVertical = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            // y axies
            offset = Quaternion.AngleAxis(rotateHorizontal, Vector3.up) * offset;

            // x axies
            offset = Quaternion.AngleAxis(rotateVertical, transform.right) * offset;

            transform.LookAt(targetPosition);
        }
    }
}
