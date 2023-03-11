using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasController : MonoBehaviour
{
    public Camera GameCamera;
    public Camera GMCamera;

    private float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                GMCamera.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            }
            else
            {
                GameCamera.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                GMCamera.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            }
            else
            {
                GameCamera.transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                GMCamera.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
            else
            {
                GameCamera.transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                GMCamera.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
            else
            {
                GameCamera.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                GMCamera.orthographicSize -= speed * Time.deltaTime;
            }
            else
            {
                GameCamera.orthographicSize -= speed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                GMCamera.orthographicSize += speed * Time.deltaTime;
            }
            else
            {
                GameCamera.orthographicSize += speed * Time.deltaTime;
            }
        }
    }

    public void MoveCamerasToPosition(Vector3 position, float zoomSize = 12f)
    {
        GameCamera.transform.position = new Vector3(position.x, position.y, GameCamera.transform.position.z);
        GMCamera.transform.position = new Vector3(position.x, position.y, GMCamera.transform.position.z);
        GameCamera.orthographicSize = zoomSize;
        GMCamera.orthographicSize = zoomSize;
    }
}