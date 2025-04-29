using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDEATHcounter : MonoBehaviour
{
    public TextMeshProUGUI DEATHCOUNTER;
    public GameObject hintButton;


    public void Start()
    {
        if (PlayerPrefs.GetInt("hintcount") < 3){
            hintButton.SetActive(false);
        }
    }

    public void HintAction()
    {
        hintButton.SetActive(false);
        PlayerPrefs.SetInt("hintcount", 0);
    }

    public void SetButtonActive(bool active)
    {
        hintButton.SetActive(active);
    }
  
    public void SetDeathText(int deathNumber)
    {
        DEATHCOUNTER.text = "Player Death: " + deathNumber;
    }
}
