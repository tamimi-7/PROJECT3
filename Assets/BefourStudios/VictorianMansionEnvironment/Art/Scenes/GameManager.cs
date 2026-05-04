using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public TMP_Text counterText;      
    public GameObject escapeDoor;     
    public AudioSource doorAudio;    
    public AudioClip doorOpenSound;   

    private int activeGramophones = 0;

    void Start()
    {
        counterText.text = "0 / 3";
    }

    public void AddGramophone()
    {
        activeGramophones++;
        counterText.text = activeGramophones + " / 3";

        
        if (activeGramophones >= 3)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        
        if (doorAudio != null && doorOpenSound != null)
        {
            doorAudio.PlayOneShot(doorOpenSound);
        }

      
        if (escapeDoor != null)
        {
            escapeDoor.SetActive(false);
        }
    }
}