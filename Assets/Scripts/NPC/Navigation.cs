using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject Player;


   

    void Start()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
    }

    void Update()
    {
        _agent.destination = Player.transform.position;
       
    }
}
