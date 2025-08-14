using UnityEngine;

public class PlaySound : MonoBehaviour
{

    private AudioSource asCurrent;
    public GameManager gm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        asCurrent = gameObject.GetComponent<AudioSource>();
        asCurrent.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.musicOn && !asCurrent.isPlaying)
        {
            asCurrent.Play();
        }
        else if (!gm.musicOn && asCurrent.isPlaying)
        {
            asCurrent.Stop();
        }



    }

    
}
