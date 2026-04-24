using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 3.0f;
    public KeyCode interactKey = KeyCode.E;
    public Camera playerCamera;


    public JournalManager journal;

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

            string tagTouche = hit.collider.tag;


            if (tagTouche == "Necklace" || tagTouche == "Pantalon" ||tagTouche == "Cintre" || tagTouche == "Chaussure" || tagTouche == "Montre")
            {
  
                if (journal != null)
                {
                    journal.RemoveItemFromJournal(tagTouche);
                }

                Debug.Log("Item regardé et ramassé : " + hit.collider.name);

                // On détruit l'objet 3D de la scène
                Destroy(hit.collider.gameObject);
            }
        }
    }
}