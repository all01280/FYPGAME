using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public GameObject UI;
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    bool UnLock;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
              Cursor.lockState = CursorLockMode.None;
              Cursor.visible = true;
              mouseSensitivity = 0f;
              UI.SetActive(true);
            //UnLock = !UnLock;
        }
        //if (UnLock)
        //{
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //    mouseSensitivity = 0f;
        //    UI.SetActive(true);
        //}
        //else
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //    Cursor.visible = false;
        //    mouseSensitivity = 100f;
        //    UI.SetActive(false);
        //}

    }
    public void OffPause()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mouseSensitivity = 100f;
        UI.SetActive(false);
    }
}
