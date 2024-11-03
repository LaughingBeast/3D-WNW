using UnityEngine;

public class NPCstats : MonoBehaviour
{
    
    public float HP = 100;
    
    


    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

  

}
