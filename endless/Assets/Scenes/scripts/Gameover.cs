using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public TMP_Text textMeshProComponent;
    void Update()
    {
        
         if (gameObject.name == "scorepoint")
        { textMeshProComponent.text = Game_Manager.score.ToString(); }
            else if(gameObject.name =="highpoint")
        {
            textMeshProComponent.text = Game_Manager.highScore.ToString();
        }
    }
}
