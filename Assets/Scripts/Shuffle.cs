using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class RoomManager : MonoBehaviour
{
    public Transform player;
    public List<Transform> allRooms;

    private Transform currentRoom;
    private Transform previousRoom;

    void Update()
    {
        Transform closestRoom = GetClosestRoom();

        if (closestRoom != currentRoom)
        {
            previousRoom = currentRoom;
            currentRoom = closestRoom;

            if (previousRoom != null)
            {
                ShuffleExcept(currentRoom, previousRoom);
            }
        }
    }

    Transform GetClosestRoom()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 playerPos = player.position;

        foreach (Transform room in allRooms)
        {
            Vector3 directionToTarget = room.position - playerPos;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = room;
            }
        }
        return bestTarget;
    }

    void ShuffleExcept(Transform roomA, Transform roomB)
    {
        List<Transform> roomsToShuffle = new List<Transform>();
        List<Vector3> positions = new List<Vector3>();

        // 1. Filtrage des pièces
        foreach (Transform r in allRooms)
        {
            if (r != roomA && r != roomB)
            {
                roomsToShuffle.Add(r);
                positions.Add(r.position);
            }
        }

        // 2. Mélange des positions
        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 temp = positions[i];
            int randomIndex = Random.Range(i, positions.Count);
            positions[i] = positions[randomIndex];
            positions[randomIndex] = temp;
        }

        // 3. OPTIMISATION : On coupe la navigation avant de bouger
        // On récupère tous les agents des pièces qui vont bouger
        List<NavMeshAgent> movingAgents = new List<NavMeshAgent>();
        foreach (Transform r in roomsToShuffle)
        {
            movingAgents.AddRange(r.GetComponentsInChildren<NavMeshAgent>());
        }

        foreach (NavMeshAgent agent in movingAgents)
        {
            agent.enabled = false; // Désactive l'IA pour qu'elle ne panique pas pendant le TP
        }

        // 4. Déplacement physique (Téléportation)
        for (int i = 0; i < roomsToShuffle.Count; i++)
        {
            roomsToShuffle[i].position = positions[i];
        }

        // 5. On réactive les agents (Ils sont maintenant à leur nouvelle place avec la pièce)
        foreach (NavMeshAgent agent in movingAgents)
        {
            agent.enabled = true;
        }

        Debug.Log("Shuffle fluide terminé !");
    }
}