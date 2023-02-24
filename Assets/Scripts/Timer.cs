using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    float segundos = 1f;
    int minutos = 4;
    bool acabouTempo = false;
    bool comecouTimer = false;

    public GameObject acabouTempoPanel;

    public Text countdown;

    void Start()
    {
        countdown.text = "Tempo: 04:00";
    }

    private void Update()
    {
        if (acabouTempo)
        {
            segundos = 0;
            countdown.text = "Tempo: 00:00";
            GameObject.FindGameObjectWithTag("Canvas").GetComponent<ControleCanvas>().DesfixarMousePrenderPers();
            acabouTempoPanel.SetActive(true);
        }
        else
        {
            if (comecouTimer)
            {
                if (minutos == 0 && segundos <= 0)
                {
                    acabouTempo = true;
                }
                else if (segundos <= 0)
                {
                    segundos = 59f;
                    minutos--;
                }

                segundos -= 1 * Time.deltaTime;


                if (segundos < 10)
                {
                    countdown.text = "Tempo: " + "0" + minutos.ToString() + ":0" + segundos.ToString("0");
                }
                else
                {
                    countdown.text = "Tempo: " + "0" + minutos.ToString() + ":" + segundos.ToString("0");
                }
            }
            else
            {
                segundos -= 1 * Time.deltaTime;
                if (segundos < 0)
                {
                    segundos = 59;
                    minutos--;
                    comecouTimer = true;
                }
            }
        }
    }

    public float TempoGasto()
    {
        int seg = (int)segundos;
        return (3 - minutos) + (0.01f * (60 - seg));
    }
}