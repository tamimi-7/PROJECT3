using UnityEngine;

public class PianoController : MonoBehaviour
{
    public AudioSource pianoSound;
    public GameObject uiHint;
    private bool isPlayerClose = false;

    void Update()
    {
        if (isPlayerClose && Input.GetKeyDown(KeyCode.E))
        {
            if (pianoSound.isPlaying)
                pianoSound.Stop();
            else
                pianoSound.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = true;
            uiHint.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerClose = false;
            uiHint.SetActive(false);
        }
    }
}