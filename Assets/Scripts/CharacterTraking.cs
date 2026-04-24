using UnityEngine;
using UnityEngine.AI;

public class CharacterTraking : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform playerTransform;
    [SerializeField] FlashlightController flashlight;
    [SerializeField] Vector3 offset = new Vector3(0, 1.0f, 0);
    [SerializeField] float LightAngle = 45;
   

    void Update()
    {


        if (CanMove())
        {
            agent.isStopped = false;
            agent.SetDestination(playerTransform.position);
        }
        else
        {
            agent.isStopped = true;
        }
            
    }


    bool CanMove()
    {
        if (!flashlight.isOn)
        {
            return false;
        }

        Vector3 targetPoint = transform.position + offset;


        Vector3 DirectionToAI = (transform.position - flashlight.transform.position).normalized;
      
        float angleBetween = Vector3.Angle(flashlight.transform.forward, DirectionToAI);
        Debug.Log(DirectionToAI);
        Debug.Log("Angle" + angleBetween);
        Debug.DrawRay(flashlight.transform.position, DirectionToAI * 5f, Color.red);
        if (angleBetween <  LightAngle)
        {
            return false;
        }
        else
        {
            return true;
        }

       


    }
        
}