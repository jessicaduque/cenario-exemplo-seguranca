using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    // Se a câmera pode ou não se mexer
    bool canMove = true;

    public Transform characterBody;
    public Transform characterHead;

    float rotationX = 180;
    float rotationY = 0;

    public float SensibilityX = 0.5f;
    public float SensibilityY = 0.5f;

    float angleYMin = -90;
    float angleYMax = 90;

    float smootRotx = 0;
    float smootRoty = 0;

    float smoothCoefy = 0.005f;
    float smoothCoefx = 0.005f;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().IfCanMove(1);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FirstPersonCam>().IfCanMove(1);
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }

    void Update()
    {
        if (canMove)
        {
            float verticalDelta = Input.GetAxisRaw("Mouse Y") * SensibilityY;
            float horizontalDelta = Input.GetAxisRaw("Mouse X") * SensibilityX;

            smootRotx = Mathf.Lerp(smootRotx, horizontalDelta, smoothCoefx);
            smootRoty = Mathf.Lerp(smootRoty, verticalDelta, smoothCoefy);

            rotationX += horizontalDelta;
            rotationY += verticalDelta;

            rotationY = Mathf.Clamp(rotationY, angleYMin, angleYMax);

            characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }

    public void IfCanMove(int move)
    {
        if (move == 0)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }
}