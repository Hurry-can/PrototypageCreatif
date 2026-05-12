using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI; // AJOUT : Nécessaire pour NavMesh

// AJOUT : Pour accéder à NavMeshSurface
using Unity.AI.Navigation;

public class RoomManager : MonoBehaviour
{
    public Transform player;
    public List<Transform> allRooms;

    private Transform currentRoom;
    private Transform previousRoom;
    private List<NavMeshSurface> navMeshSurfaces = new List<NavMeshSurface>();

    void Start()
    {
        // AJOUT : On récupère toutes les NavMeshSurfaces au démarrage
        foreach (Transform r in allRooms)
        {
            NavMeshSurface surface = r.GetComponent<NavMeshSurface>();
            if (surface != null)
            {
                navMeshSurfaces.Add(surface);
            }
        }
    }

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

        foreach (Transform r in allRooms)
        {
            if (r != roomA && r != roomB)
            {
                roomsToShuffle.Add(r);
                positions.Add(r.position);
            }
        }

        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 temp = positions[i];
            int randomIndex = Random.Range(i, positions.Count);
            positions[i] = positions[randomIndex];
            positions[randomIndex] = temp;
        }

        for (int i = 0; i < roomsToShuffle.Count; i++)
        {
            roomsToShuffle[i].position = positions[i];
        }

        // --- AJOUT : LA CORRECTION POUR LE NAVMESH ---
        // On force les PNJs à désactiver temporairement leur navigation pour qu'ils suivent le parent
        foreach (NavMeshSurface surface in navMeshSurfaces)
        {
            NavMeshAgent[] agents = surface.GetComponentsInChildren<NavMeshAgent>();
            foreach (NavMeshAgent agent in agents)
            {
                agent.enabled = false;
            }
        }

        // On fait le "re-bake" de toutes les surfaces
        foreach (NavMeshSurface surface in navMeshSurfaces)
        {
            // Cette fonction est optimisée pour être rapide
            surface.BuildNavMesh();
        }

        // On réactive les agents
        foreach (NavMeshSurface surface in navMeshSurfaces)
        {
            NavMeshAgent[] agents = surface.GetComponentsInChildren<NavMeshAgent>();
            foreach (NavMeshAgent agent in agents)
            {
                agent.enabled = true;
            }
        }

        Debug.Log("Shuffle effectué et NavMesh mis à jour !");
    }
}