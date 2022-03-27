using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    [SerializeField][Range(0f, 200f)]
    private float mouseSensivity;
    private float mouseX, mouseY, xAxisClamp;
    private GameObject playerCamera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera = Camera.main.gameObject;
    }

    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xAxisClamp -= mouseY;

        xAxisClamp = Mathf.Clamp(xAxisClamp, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(Vector3.right * xAxisClamp);
        transform.Rotate(Vector3.up * mouseX);
    }
}
