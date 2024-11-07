using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public NPCstats EnemyScript;
    public GameObject HealthBarObj;
    public GameObject HealthBarEaserObj;
    public Slider _healthSlider;
    public Slider _easeHealthSlider;
    public float _currentHealth;
    public float _lerpSpeed = 0.05f;
    void Start()
    {
        _currentHealth = EnemyScript.HP; 
        _healthSlider.value = _currentHealth;
        HealthBarObj.SetActive(false);
        HealthBarEaserObj.SetActive(false);

    }
    
    void Update()
    {
        _currentHealth = EnemyScript.HP;
        if (_healthSlider.value != _currentHealth)
        {
            HealthBarObj.SetActive(true);
            HealthBarEaserObj.SetActive(true);
            _healthSlider.value = _currentHealth;
            
        }


        if (_healthSlider.value != _easeHealthSlider.value)
        {
            _easeHealthSlider.value = Mathf.Lerp(_easeHealthSlider.value,_currentHealth,_lerpSpeed);
        } 

        if ( _healthSlider.value >= _easeHealthSlider.value - 1)
        {
            HealthBarObj.SetActive(false);
            HealthBarEaserObj.SetActive(false);
        }
        

        
    }
}
