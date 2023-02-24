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
    float tempoGasto = 0.0f;

    public GameObject ResultadosPanel;
    public Text pontuacao;
    public Text descricaoPont;
    string feedback = "";

    public AudioClip SomCheck;

    // Start is called before the first frame update
    void Start()
    {
        pontuacao.text = null;
        descricaoPont.text = null;
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
        int k;
        erros[0] = fumar;
        erros[1] = epi;
        erros[2] = ventilacao;
        erros[3] = sinalizacaoCima;
        erros[4] = sinalizacaoLateral;
        for (k = 0; k < 5; k++)
        {
            if (erros[k])
            {
                somaPontos += 20;
            }
        }
        if(k == 5)
        {
            if(tempoGasto > 1.4)
            {
                if (tempoGasto < 3)
                {
                    somaPontos -= 15;
                }
                else
                {
                    somaPontos -= 30;
                }
            }
            if(somaPontos < 0)
            {
                somaPontos = 0;
            }
            
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
        if (!sinalizacaoCima || !sinalizacaoLateral)
        {
            feedback += "- Passou despercebido nos tanques de fermenta��o das uvas alguma sinaliza��o n�o existente, e necess�ria.\n";
        }
        if(somaPontos == 100)
        {
            feedback = "Parab�ns, voc� encontrou todos os erros de seguran�a no ambiente desta fase.\n";
        }

        // Quest�o do tempo
        if (tempoGasto < 1.4)
        {
            feedback += "- Voc� obteve um �timo tempo para fazer a an�lise, parab�ns!\n";
        }
        else if(tempoGasto < 3)
        {
            feedback += "- Voc� foi um pouco lento para fazer a an�lise da fase. Tente ser mais eficiente.\n";
        }
        else
        {
            feedback += "- Mesmo sem pressa de checar o ambiente, � sempre bom fazer uma an�lise eficiente, j� sabendo quais fatores podem estar erradas. Assim, voc� demorou demais para completar a fase.\n";
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

                if (checkMarks[j].sprite != checkPreenchido)
                {
                    ControlaAudio.instancia.PlayOneShot(SomCheck);
                }
                checkMarks[j].sprite = checkPreenchido;
            }
            if(j == objetivosQuant)
            {
                objetivosQuant = 0;
            }
        }
    }

    public void CalcularTempo()
    {
        tempoGasto = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().TempoGasto();
    }
}
