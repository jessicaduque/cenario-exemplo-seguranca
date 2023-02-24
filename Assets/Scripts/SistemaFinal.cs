using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaFinal : MonoBehaviour
{
    bool epi = false;
    bool fumar = false;
    bool ventilacao = false;
    bool sinalizacaoCima = false;
    bool sinalizacaoLateral = false;

    bool[] erros = new bool[5];
    public Image[] checkMarks;

    public Sprite checkPreenchido;

    int somaPontos = 0;
    int objetivosQuant = 0;

    public GameObject ResultadosPanel;
    public Text pontuacao;
    public Text descricaoPont;
    string feedback = "";

    // Start is called before the first frame update
    void Start()
    {
        pontuacao.text = null;
        descricaoPont.text = null;
        //objetivosQuantText.text = "Objetivos: 0/4";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ErrosReconhecidos(string nome)
    {
        if(nome == "epi")
        {
            epi = true;
        }
        if (nome == "fumar")
        {
            fumar = true;
        }
        if (nome == "tanquecima")
        {
            sinalizacaoCima = true;
        }
        if (nome == "tanquelateral")
        {
            sinalizacaoLateral = true;
        }
        if (nome == "ventilacao")
        {
            ventilacao = true;
        }
    }

    public void CalcularResulado()
    {
        erros[0] = fumar;
        erros[1] = epi;
        erros[2] = ventilacao;
        erros[3] = sinalizacaoCima;
        erros[4] = sinalizacaoLateral;
        for (int k = 0; k < 5; k++)
        {
            if (erros[k])
            {
                somaPontos += 20;
            }
        }
    }

    public void MontarFeedback()
    {
        // Feedback pontuação obtido
        pontuacao.text = "Pontuação: " + somaPontos.ToString() + "/100";

        // Feedback descritivo
        if (!epi)
        {
            feedback += "- Faltou reconhecer o funcionário sem uso correto de EPI's (Luvas e touca).\n";
        }
        if (!fumar)
        {
            feedback += "- Faltou reconhecer o erro de um funcionário ao fumar dentro do ambiente de trabalho.\n";
        }
        if (!ventilacao)
        {
            feedback += "- Faltou reconhecer uma inadequação do ambiente, a falta de ventilação apropriada.\n";
        }
        if (!sinalizacaoCima || !sinalizacaoLateral)
        {
            feedback += "- Passou despercebido nos tanques de fermentação das uvas alguma sinalização não existente, e necessária.\n";
        }
        if(somaPontos == 100)
        {
            feedback = "Parabéns, você encontrou todos os erros de segurança no ambiente desta fase.\nTambém, fez dentro de um ótimo tempo.";
        }
    }

    public void MostrarResultados()
    {
        ResultadosPanel.SetActive(true);
        pontuacao.gameObject.SetActive(true);
        descricaoPont.text = feedback;
        descricaoPont.gameObject.SetActive(true);
    }
    
    public void QuantidadeObjetivos()
    {
        int i;
        int j;
        erros[0] = fumar;
        erros[1] = epi;
        erros[2] = ventilacao;
        erros[3] = sinalizacaoCima;
        erros[4] = sinalizacaoLateral;

        for (i = 0; i < 5; i++)
        {
            if (erros[i])
            {
                objetivosQuant++;
            }
        }
        if(i == 5)
        {
            for (j = 0; j < objetivosQuant; j++)
            {
                checkMarks[j].sprite = checkPreenchido;
            }
            if(j == objetivosQuant)
            {
                objetivosQuant = 0;
            }
        }
    }
}
