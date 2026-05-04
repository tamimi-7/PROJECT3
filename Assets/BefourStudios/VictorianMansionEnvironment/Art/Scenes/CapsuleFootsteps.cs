using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(NavMeshAgent))]
public class CapsuleFootsteps : MonoBehaviour
{
    public AudioClip[] footstepSounds; 
    public float stepDistance = 1.5f;  

    private AudioSource audioSource;
    private NavMeshAgent agent;
    private Vector3 lastStepPosition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        lastStepPosition = transform.position;
    }

    void Update()
    {
       
        if (agent.velocity.sqrMagnitude > 0.1f && !agent.isStopped)
        {
            
            float distanceMoved = Vector3.Distance(transform.position, lastStepPosition);

            
            if (distanceMoved >= stepDistance)
            {
                PlayFootstep();
                lastStepPosition = transform.position; 
            }
        }
        else
        {
            
            lastStepPosition = transform.position;
        }
    }

    void PlayFootstep()
    {
        
        if (footstepSounds.Length > 0)
        {
           
            int randomIndex = Random.Range(0, footstepSounds.Length);

        
            audioSource.pitch = Random.Range(0.9f, 1.1f);

         
            audioSource.PlayOneShot(footstepSounds[randomIndex]);
        }
    }
}