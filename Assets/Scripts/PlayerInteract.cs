using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Configuration")]
    public float interactionDistance = 3.0f; // Distance max de 3m
    public KeyCode interactKey = KeyCode.E;   // Touche pour ramasser
    public Camera playerCamera;              // Glisse ta caméra ici

    void Update()
    {
        // On vérifie si la touche E est pressée
        if (Input.GetKeyDown(interactKey))
        {
            CheckAndPickUp();
        }
    }

    void CheckAndPickUp()
    {
        // On crée un rayon qui part du centre de la vue (Caméra)
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // On lance le rayon physiquement dans la scène
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Si le rayon touche quelque chose qui a le tag "Item"
            if (hit.collider.CompareTag("Item"))
            {
                Debug.Log("Item regardé et ramassé : " + hit.collider.name);
                Destroy(hit.collider.gameObject);
            }
        }
    }

    // Pour t'aider à visualiser le rayon dans l'éditeur (Scene)
    void OnDrawGizmos()
    {
        if (playerCamera != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * interactionDistance);
        }
    }
}