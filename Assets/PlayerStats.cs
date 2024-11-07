using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameManager GameManager;
    private GameObject _player; 
    public Slider _healthSlider;
    public Slider _easeHealthSlider;
    public float _currentHealth;
    public float _lerpSpeed = 0.05f;
    
    void Start()
    {
        _player = GameManager.Player;
        _currentHealth = _player.GetComponent<Player>().HP;
        _healthSlider.value = _currentHealth;
    }


    void Update()
    {
        

        _currentHealth = _player.GetComponent<Player>().HP;
        if (_healthSlider.value != _currentHealth)
        {
            _healthSlider.value = _currentHealth;

        }


        if (_healthSlider.value != _easeHealthSlider.value)
        {
            _easeHealthSlider.value = Mathf.Lerp(_easeHealthSlider.value, _currentHealth, _lerpSpeed);
        }


    }
}
