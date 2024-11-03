using System.Collections;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public AudioSource AudioPlayer;
    
    private ParticleSystem _fire0;
    private GameObject _particleSystemPositionFire;
    [SerializeField]   
    private float _dmg;

    [SerializeField]
    private float Range = 10f;
    LayerMask layerMask;
    bool _fireSound = false;



    private void Start()
    {
        _fire0 = Resources.Load<ParticleSystem>("ParticleSystem/AK-Fire");
        _particleSystemPositionFire = gameObject.transform.GetChild(0).GameObject();

        layerMask = LayerMask.GetMask("Wall", "Enemy");
        Range = 10f;


    }


    void Update()
    {

        RaycastHit hit;
        

        if (Input.GetKey(KeyCode.Mouse0))
        {
            var _fireParticles = Instantiate(_fire0, _particleSystemPositionFire.transform.position, gameObject.transform.rotation);
            StartCoroutine(FireParticle(_fireParticles));
            if (!AudioPlayer.isPlaying)
            {

                AudioPlayer.Play();
            }
            


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
        } else { AudioPlayer.Stop(); }

    }


    IEnumerator FireParticle(ParticleSystem fireParticles) //Dodìlat spoždìní Fire
    {

        fireParticles.transform.TransformDirection(Vector3.forward);

        yield return 600;
    }

}