using UnityEngine;
using System.Collections.Generic;

public class GestionnaireEchange : MonoBehaviour
{
    public GameObject[] cubes; // Glissez vos cubes ici dans l'inspecteur

    void Update()
    {

        if (Random.Range(1, 2) == 1)
        {
            EchangerPositions();
        }
    }

    void EchangerPositions()
    {
        if (cubes.Length < 2) return;


        List<Vector3> positions = new List<Vector3>();
        foreach (GameObject cube in cubes)
        {
            positions.Add(cube.transform.position);
        }

        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 temp = positions[i];
            int randomIndex = Random.Range(i, positions.Count);
            positions[i] = positions[randomIndex];
            positions[randomIndex] = temp;
        }

        // On réattribue les nouvelles positions aux cubes
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].transform.position = positions[i];
        }

        Debug.Log("Positions échangées !");
    }
}