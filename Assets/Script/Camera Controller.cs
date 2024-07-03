using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 10f;       // 鼠标滚轮缩放速度
    public float rotationSpeed = 100f;  // 鼠标旋转速度

    private Vector3 offset;
    private Transform playerTransform;

    void Start()
    {
        // 查找 "Player" 对象并计算初始偏移
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    void Update()
    {
        // 更新摄像机位置，使其跟随 "Player"
        transform.position = playerTransform.position + offset;

        // 缩放摄像机视野
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Camera.main.fieldOfView += scroll * zoomSpeed;
        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 37, 70);

        // 处理摄像机旋转
        if (Input.GetMouseButton(1)) // 右键按下时旋转摄像机
        {
            // 获取鼠标的水平和垂直输入
            float rotateHorizontal = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotateVertical = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime; // 反转 y 轴方向

            // 水平旋转（围绕世界的 Y 轴）
            offset = Quaternion.AngleAxis(rotateHorizontal, Vector3.up) * offset;

            // 垂直旋转（围绕摄像机的本地 X 轴）
            offset = Quaternion.AngleAxis(rotateVertical, transform.right) * offset;

            // 确保摄像机继续面对 "Player" 对象
            transform.LookAt(playerTransform.position);
        }
    }
}
