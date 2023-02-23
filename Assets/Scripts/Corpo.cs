using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corpo : MonoBehaviour
{
    // Para determinar se o player pode se mexer ou não
    bool canMove = true;

    public GameObject FinPanel;
    public Text AvisoTanques;

    CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    public float forwardSpeed = 20f;
    public float strafeSpeed = 20f;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / (timeToMaxHeight);

    }


    void Update()
    {
        if (canMove)
        {
            float forwardInput = Input.GetAxisRaw("Vertical");
            float strafeInput = Input.GetAxisRaw("Horizontal");

            forward = forwardInput * forwardSpeed * transform.forward;
            strafe = strafeInput * strafeSpeed * transform.right;

            vertical += gravity * Time.deltaTime * Vector3.up;

            if (controller.isGrounded)
            {
                vertical = Vector3.down;
            }

            if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
            {
                vertical = jumpSpeed * Vector3.up;
            }

            if (vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
            {
                vertical = Vector3.zero;
            }


            Vector3 finalVelocity = forward + strafe + vertical;

            controller.Move(finalVelocity * Time.deltaTime);
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
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "PontoFinal")
        {
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<ControleCanvas>().DesfixarMousePrenderPers();
            FinPanel.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Escada")
        {
            Debug.Log("NA ESCADA");
            vertical = new Vector3(0, 0.55f, 0);
        }
        if (col.gameObject.tag == "cimatanque")
        {
            AvisoTanques.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "cimatanque")
        {
            AvisoTanques.gameObject.SetActive(false);
        }
    }
}