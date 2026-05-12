using UnityEngine;

public class soundcue : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepClip;

    public float timeBetweenSteps = 0.5f;
    private float timer;

    private Vector3 lastPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastPosition = transform.position;

        timer = timeBetweenSteps;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        bool isMoving = distanceMoved > 0.001f;

        if (isMoving)
        {

            if (!audioSource.isPlaying)
            {
                audioSource.clip = footstepClip;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
           if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        lastPosition = transform.position;
        
    }
    void PlayStep ()
    {
        if (audioSource !=null && footstepClip !=null)
        {
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(footstepClip);
        }
    }
}
