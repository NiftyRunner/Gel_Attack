using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    public int scoreCount = 0;

    void Start()
    {
        score.text = new string("0");        
    }

    void Update()
    {
        score.text = new string("" + scoreCount);
    }
}
