using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaFinal : MonoBehaviour
{
    bool epi = false;
    bool fumar = false;
    bool ventilacao = false;
    bool sinalizacao = false;

    bool[] erros = new bool[4];

    int somaPontos = 0;
    //int objetivosQuant = 0;

    public GameObject ResultadosPanel;
    public Text pontuacao;
    public Text descricaoPont;
    //public Text objetivosQuantText;
    string feedback = "";

    // Start is called before the first frame update
    void Start()
    {
        erros[0] = epi;
        erros[1] = fumar;
        erros[2] = ventilacao;
        erros[3] = sinalizacao;
        pontuacao.text = null;
        descricaoPont.text = null;
        //objetivosQuantText.text = "Objetivos: 0/4";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ErrosReconhecidos(string titulo)
    {
        if(titulo == "Falta de uso de luvas e de touca")
        {
            epi = true;
        }
    }

    public void CalcularResulado()
    {
        if (epi)
        {
            somaPontos += 25;
        }
        if (fumar)
        {
            somaPontos += 25;
        }
        if (ventilacao)
        {
            somaPontos += 25;
        }
        if (sinalizacao)
        {
            somaPontos += 25;
        }
    }

    public void MontarFeedback()
    {
        // Feedback pontua��o obtido
        pontuacao.text = "Pontua��o: " + somaPontos.ToString() + "/100";

        // Feedback descritivo
        if (!epi)
        {
            feedback += "- Faltou reconhecer o funcion�rio sem uso correto de EPI's (Luvas e touca).\n";
        }
        if (!fumar)
        {
            feedback += "- Faltou reconhecer o erro de um funcion�rio ao fumar dentro do ambiente de trabalho.\n";
        }
        if (!ventilacao)
        {
            feedback += "- Faltou reconhecer uma inadequa��o do ambiente, a falta de ventila��o apropriada.\n";
        }
        if (!sinalizacao)
        {
            feedback += "- Faltou reconhecer que um dos tanques de fermenta��o das uvas n�o possuia a sinaliza��o necess�ria.\n";
        }
    }

    public void MostrarResultados()
    {
        ResultadosPanel.SetActive(true);
        pontuacao.gameObject.SetActive(true);
        descricaoPont.text = feedback;
        descricaoPont.gameObject.SetActive(true);
    }
    
    /*
    public void QuantidadeObjetivos()
    {
        for(int i = 0; i < 4; i++)
        {
            if (erros[i])
            {
                objetivosQuant++;
            }
        }
        objetivosQuantText.text = "Objetivos: " + objetivosQuant.ToString() + "/4";
    }*/
}
