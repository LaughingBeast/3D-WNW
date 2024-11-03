using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public NPCstats EnemyScript;
    public Slider _healthSlider;
    public Slider _easeHealthSlider;
    public float _curretnHealth;
    public float _lerpSpeed = 0.05f;
    void Start()
    {
        _curretnHealth = EnemyScript.HP; 
        _healthSlider.value = _curretnHealth;

    }

    
    void Update()
    {
        _curretnHealth = EnemyScript.HP;
        if (_healthSlider.value != _curretnHealth)
        {
            _healthSlider.value = _curretnHealth;
            
        }


        if (_healthSlider.value != _easeHealthSlider.value)
        {
            _easeHealthSlider.value = Mathf.Lerp(_easeHealthSlider.value,_curretnHealth,_lerpSpeed);
        }

        
    }
}
