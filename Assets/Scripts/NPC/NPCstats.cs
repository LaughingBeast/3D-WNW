using UnityEngine;

public class NPCstats : MonoBehaviour
{
    
    public float HP = 100;
    public AudioSource AudioPlayerHit;



    void Update()
    {
        if (HP <= 0)
        {
            AudioPlayerHit.Play();
            Destroy(gameObject);
        }
    }

  

}
