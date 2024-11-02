using System;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TMP_Text TimeText;

    public float SecondPerRound;
    private float _actualTime;

    void Start()
    {
        _actualTime = SecondPerRound;
        TimeText.text = Mathf.Round(_actualTime).ToString();
    }

    
    void Update()
    {
      _actualTime -= Time.deltaTime;
      TimeText.text = Mathf.Round(_actualTime).ToString();
    }
}
