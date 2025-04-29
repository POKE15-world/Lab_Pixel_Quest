using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDEATHcounter : MonoBehaviour
{
    public TextMeshProUGUI DEATHCOUNTER;
  
    public void SetDeathText(int deathNumber)
    {
        DEATHCOUNTER.text = "Player Death: " + deathNumber;
    }
}
