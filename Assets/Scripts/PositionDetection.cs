using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionDetection : MonoBehaviour
{
    public ListaDePociones ListBalls;
    public GameObject trigger;
    private float distanciaL;
    private float distanciaR;

    public ParticleSystem particulaAciertoL;
    public ParticleSystem particulaAciertoR;

    void Update()
    {
        if (ListBalls.PotionsInGameL.Count != 0)
        {
            distanciaL = ListBalls.PotionsInGameL[0].transform.position.y - trigger.transform.position.y;
            //Debug.Log(distancia);

            if (distanciaL < 0)
                distanciaL = distanciaL * -1;
        }

        if (ListBalls.PotionsInGameR.Count != 0)
        {
            distanciaR = ListBalls.PotionsInGameR[0].transform.position.y - trigger.transform.position.y;
            //Debug.Log(distancia);

            if (distanciaR < 0)
                distanciaR = distanciaR * -1;
        }
    }

    public void CheckCollisionLeft()
    {
            if (distanciaL <= 0.1)
            {
                ListBalls.PotionsInGameL[0].SendMessage("Perfect");
                particulaAciertoL.Play();
            }
            else if (distanciaL <= 0.5)
            {
                ListBalls.PotionsInGameL[0].SendMessage("Acierto");
                particulaAciertoL.Play();
             }
            else
            {
                GameObject.Find("Main Camera").SendMessage("Shaking");
                ListBalls.PotionsInGameL[0].SendMessage("Fallo");
            }
    }

    public void CheckCollisionRight()
    {
        if (distanciaR <= 0.1)
        {
            ListBalls.PotionsInGameR[0].SendMessage("Perfect");
            particulaAciertoR.Play();
        }
        else if (distanciaR <= 0.5)
        {
            ListBalls.PotionsInGameR[0].SendMessage("Acierto");
            particulaAciertoR.Play();
        }
        else
        {
            GameObject.Find("Main Camera").SendMessage("Shaking");
            ListBalls.PotionsInGameR[0].SendMessage("Fallo");
        }
    }
}
