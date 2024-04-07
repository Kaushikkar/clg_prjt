using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Ui : MonoBehaviour
{
    public Health_Manager Phealth;
    public TMP_Text textMeshProComponent;
    void Update()
    {
        if(gameObject.name=="health")
            textMeshProComponent.text= Phealth.health.ToString();
        else if(gameObject.name=="scorepoint")
            textMeshProComponent.text=Game_Manager.score.ToString();
    }
}
