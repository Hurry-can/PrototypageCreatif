using UnityEngine;
using UnityEngine.AI;

public class CharacterTraking : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform playerTransform; // Le joueur


    

    void Update()
    {
            agent.isStopped = false;
            agent.SetDestination(playerTransform.position);
        }
        
}