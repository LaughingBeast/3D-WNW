using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public NPCstats EnemyScript;
    public Slider _healthSlider;
    public Slider _easeHealthSlider;
    private float _curretnHealth;
    private float _lerpSpeed = 0.05f;
    void Start()
    {
        _curretnHealth = EnemyScript.HP; // NEREGISTRUJE SE HP Z JINEHO SCRIPTU
       

    }

    
    void Update()
    {
        //_curretnHealth--;
        if (_healthSlider.value != _curretnHealth)
        {
            _healthSlider.value = _curretnHealth;
            print(_curretnHealth);
        }


        if (_healthSlider.value != _easeHealthSlider.value)
        {
            _easeHealthSlider.value = Mathf.Lerp(_easeHealthSlider.value,_curretnHealth,_lerpSpeed);
        }

        
    }
}
