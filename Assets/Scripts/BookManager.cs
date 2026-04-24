using UnityEngine;

public class JournalManager : MonoBehaviour
{
    public GameObject livrePanel;
    private bool isBookOpen = false;


    public GameObject uiPantalon;
    public GameObject uiMontre;
    public GameObject uiChaussure;
    public GameObject uiCintre;
    public GameObject uiCollier;


    private int itemsRestants = 5;
    public GameObject ecranVictoire; 

    void Start()
    {
        livrePanel.SetActive(false);
        if (ecranVictoire != null) ecranVictoire.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleBook();
        }
    }

    public void ToggleBook()
    {
        isBookOpen = !isBookOpen;
        livrePanel.SetActive(isBookOpen);


        Cursor.lockState = isBookOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isBookOpen;
        Time.timeScale = isBookOpen ? 0f : 1f;
    }

    public void RemoveItemFromJournal(string itemTag)
    {
        switch (itemTag)
        {
            case "Pantalon": if (uiPantalon.activeSelf) { uiPantalon.SetActive(false); itemsRestants--; } break;
            case "Montre": if (uiMontre.activeSelf) { uiMontre.SetActive(false); itemsRestants--; } break;
            case "Chaussure": if (uiChaussure.activeSelf) { uiChaussure.SetActive(false); itemsRestants--; } break;
            case "Cintre": if (uiCintre.activeSelf) { uiCintre.SetActive(false); itemsRestants--; } break;
            case "Necklace": if (uiCollier.activeSelf) { uiCollier.SetActive(false); itemsRestants--; } break;
        }

        // --- VÉRIFICATION DE LA VICTOIRE ---
        if (itemsRestants <= 0)
        {
            GagnerLaPartie();
        }
    }

    void GagnerLaPartie()
    {
        Debug.Log("Félicitations ! Tous les objets sont trouvés.");

        if (ecranVictoire != null)
        {
            ecranVictoire.SetActive(true);


            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            // Optionnel : figer le jeu
            // Time.timeScale = 0f; 
        }
    }
}