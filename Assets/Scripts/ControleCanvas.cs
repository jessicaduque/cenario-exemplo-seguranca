using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleCanvas : MonoBehaviour
{
    public GameObject HUDPanel;


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
        HUDPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().IfCanMove(0);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FirstPersonCam>().IfCanMove(0);
    }

    public void DesfixarMousePrenderPers()
    {
        HUDPanel.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Corpo>().IfCanMove(1);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FirstPersonCam>().IfCanMove(1);
    }

    public void Recomecar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }

}
