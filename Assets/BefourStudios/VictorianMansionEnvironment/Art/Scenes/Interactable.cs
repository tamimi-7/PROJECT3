using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum ObjectType { Gramophone, Piano }
    public ObjectType type;

    public GameManager gameManager;
    public WinManager winManager;
    public GameObject interactPrompt; 

    private bool isActivated = false;
    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && !isActivated && Input.GetKeyDown(KeyCode.E))
        {
            ActivateObject();
        }
    }

    void ActivateObject()
    {
        isActivated = true;

        
        if (interactPrompt != null) interactPrompt.SetActive(false);

        if (type == ObjectType.Gramophone)
        {
            gameManager.AddGramophone();
            GetComponent<AudioSource>()?.Play();
        }
        else if (type == ObjectType.Piano)
        {
            winManager.TriggerWin();
        }
    }

    void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Player") && !isActivated)
        {
            isPlayerNear = true;
            if (interactPrompt != null) interactPrompt.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (interactPrompt != null) interactPrompt.SetActive(false);
        }
    }
}