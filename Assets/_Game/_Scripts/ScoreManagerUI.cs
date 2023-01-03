using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagerUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    
    public void UpdateGoals(int teamLeft, int teamRight)
    {
        scoreText.text = $"Score: {teamLeft} - {teamRight}";
    }
}
