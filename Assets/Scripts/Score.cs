using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float score;

    public TextMeshProUGUI UiScore;

    public float multiplicador;
    public float goodTouchs;
    private float scoreWin;

    private float delayScoreUI;

    // Start is called before the first frame update
    void Start()
    {
        

        multiplicador = 1;
        score = 0.0f;

        UiScore.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(goodTouchs >= 80)
        {
            multiplicador = 10;
        }
        else if (goodTouchs >= 60)
        {
            multiplicador = 8;
        }
        else if (goodTouchs >= 40)
        {
            multiplicador = 4;
        }
        else if (goodTouchs >= 20)
        {
            multiplicador = 2;
        }
        else
        {
            multiplicador = 1;
        }

        if (delayScoreUI > 0)
        {
            delayScoreUI -= 0.1f;
        }
        else
            //UiScore.enabled = false;


        UiScore.text = "+" + scoreWin;
    }

    public void BadTouch()
    {
        goodTouchs = 0;

        scoreWin = 0;
    }
    
    public void NiceTouch()
    {

        scoreWin = 0;
        scoreWin += 10 * multiplicador;

        UiScore.enabled = true;
        delayScoreUI = 8f;

        score += 10 * multiplicador;
       
        goodTouchs++;
    }

    public void PerfectTouch()
    {
        scoreWin = 0;
        scoreWin += 25 * multiplicador;

        UiScore.enabled = true;
        delayScoreUI = 8f;

        score += 25 * multiplicador;
        goodTouchs++;
    }

    public void TextLeft()
    {
        UiScore.transform.position = new Vector3(17, -504, 0);
    }

    public void TextRight()
    {
        UiScore.transform.position = new Vector3(446, -504, 0);
    }
}
