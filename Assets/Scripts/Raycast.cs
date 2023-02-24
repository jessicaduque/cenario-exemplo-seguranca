using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    public GameObject TextosPanel;
    public Text titulo;
    public Text descricao;
    public Text medida;
    public GameObject checkmarkPanel;
    float timerCheck = 0.0f;

    void Start()
    {
        titulo.text = null;
        descricao.text = null;
        medida.text = null;
    }


    void Update()
    {
        timerCheck += Time.deltaTime;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, 20f))

            if (hit.collider.tag == "Object")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    timerCheck = 0;
                    checkmarkPanel.gameObject.SetActive(true);
                    GameObject.FindGameObjectWithTag("Canvas").GetComponent<ControleCanvas>().DesfixarMousePrenderPers();
                    TextosPanel.SetActive(true);
                    titulo.text = hit.transform.GetComponent<ObjectType>().objecType.titulo;
                    descricao.text = hit.transform.GetComponent<ObjectType>().objecType.descricao;
                    medida.text = hit.transform.GetComponent<ObjectType>().objecType.medida;
                    GameObject.FindGameObjectWithTag("Canvas").GetComponent<SistemaFinal>().ErrosReconhecidos(hit.transform.GetComponent<ObjectType>().objecType.nome);
                    GameObject.FindGameObjectWithTag("Canvas").GetComponent<SistemaFinal>().QuantidadeObjetivos();
                }
            }

        if(timerCheck > 3)
        {
            checkmarkPanel.gameObject.SetActive(false);
        }
    }

}