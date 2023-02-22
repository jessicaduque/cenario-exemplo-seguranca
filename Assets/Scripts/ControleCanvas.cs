using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixarMouseDesprenderPers()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().IfCanMove(0);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FirstPersonCam>().IfCanMove(0);
    }

    void DesfixarMousePresnderPers()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().IfCanMove(1);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FirstPersonCam>().IfCanMove(1);
    }

}
