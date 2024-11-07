using System.Collections;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public AudioSource AudioPlayer;
    
    public float FireRate;
    private float _fireRate;
    public ParticleSystem AKFire;
    private GameObject _particleSystemPositionFire;
    [SerializeField]   
    private float _dmg;

    [SerializeField]
    private float Range = 10f;
    LayerMask layerMask;
    bool _fireSound = false;



    private void Start()
    { 
        _fireRate = FireRate; 
        layerMask = LayerMask.GetMask("Wall", "Enemy");
        Range = 10f;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;
            _fireRate -= Time.deltaTime;
            if (_fireRate <= 0)
            {
               
                AKFire.Play();
               

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Range, layerMask))
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                    var currentEnemy = hit.collider.gameObject;
                    if (currentEnemy.TryGetComponent<NPCstats>(out NPCstats enemyScript))
                    {
                        enemyScript.HP -= _dmg;
                    }
                }
                else
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Range, Color.white);
                }

                if (!AudioPlayer.isPlaying)
                {
                    AudioPlayer.Play();
                }

                _fireRate = FireRate;
            }
        }else 
        {
            AudioPlayer.Stop();
           
            if (AKFire)
            { 
              AKFire.Stop(); 
            }
            
        }
    }


   

}