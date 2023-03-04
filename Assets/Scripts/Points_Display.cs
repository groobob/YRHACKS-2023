using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points_Display : MonoBehaviour
{
    public TMP_Text pointsText;
    public int points = 0;

    void Update()
    {
        DisplayPoints(points);
    }   

    void DisplayPoints(float pointsDisplay)
    {
        if(pointsDisplay < 0)
        {
            pointsDisplay = 0;
        }

        pointsText.text = string.Format("{0}", points);
    }
}