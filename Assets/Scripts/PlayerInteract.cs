using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Configuration")]
    public float interactionDistance = 3.0f; 
    public KeyCode interactKey = KeyCode.E;   
    public Camera playerCamera;             

    void Update()
    {

        if (Input.GetKeyDown(interactKey))
        {
            CheckAndPickUp();
        }
    }

    void CheckAndPickUp()
    {

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {

            if (hit.collider.CompareTag("Item"))
            {
                Debug.Log("Item regardé et ramassé : " + hit.collider.name);
                Destroy(hit.collider.gameObject);
            }
        }
    }



}