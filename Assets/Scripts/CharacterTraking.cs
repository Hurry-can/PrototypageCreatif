using UnityEngine;
using UnityEngine.AI;

public class CharacterTraking : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform character;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        agent.SetDestination(character.position);
        //agent.isStopped = true;
    }

}
