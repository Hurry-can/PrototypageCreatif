using UnityEngine;

public class JournalManager : MonoBehaviour
{
    public GameObject livrePanel;
    private bool isBookOpen = false;

    void Update()
    {
        // Si on appuie sur Tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleBook();
        }
    }

    void ToggleBook()
    {
        isBookOpen = !isBookOpen;

        livrePanel.SetActive(isBookOpen);


        if (isBookOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f; 
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }
}