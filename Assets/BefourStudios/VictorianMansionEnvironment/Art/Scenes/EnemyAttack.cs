using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;         
    public GameObject gameOverPanel; 
    public AudioClip jumpScareSound;  
    public float catchDistance = 0.2f;

    private AudioSource audioSource;
    private bool isCaught = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isCaught) return;

        float currentDistance = Vector3.Distance(transform.position, player.position);

        if (currentDistance <= catchDistance)
        {
            CatchPlayer();
        }
    }

    void CatchPlayer()
    {
        isCaught = true;

       
        if (jumpScareSound != null)
        {
            audioSource.PlayOneShot(jumpScareSound);
        }

        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        
        Time.timeScale = 0f;
    }
}