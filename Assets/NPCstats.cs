using UnityEngine;

public class NPCstats : MonoBehaviour
{
    [SerializeField]
    private float _hp = 100;
    [SerializeField]
    private float _hpMinus = 0.3f;
    


    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 3 && Input.GetKey(KeyCode.Mouse0))
        {
            _hp -= _hpMinus;
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
