using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public GameObject lightSource;
    private bool isOn = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightSource.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            lightSource.SetActive(isOn);
        }
    }
}
