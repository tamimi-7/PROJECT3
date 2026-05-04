using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ScaryStatueAI : MonoBehaviour
{
    public Transform player;     
    public Light flashlight;     

    private NavMeshAgent agent;
    private Renderer statueRenderer;
    private Camera mainCamera;   

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        statueRenderer = GetComponentInChildren<Renderer>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (IsBeingWatched())
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            agent.speed = 3f;
        }
    }

    bool IsBeingWatched()
    {
        
        if (!flashlight.enabled) return false;

        
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        bool inView = GeometryUtility.TestPlanesAABB(planes, statueRenderer.bounds);

        if (inView)
        {
          
            Vector3 statueCenter = statueRenderer.bounds.center;
            Vector3 directionToStatue = statueCenter - mainCamera.transform.position;
            float distanceToStatue = Vector3.Distance(mainCamera.transform.position, statueCenter);

            
            if (Physics.Raycast(mainCamera.transform.position, directionToStatue, out RaycastHit hit, distanceToStatue))
            {
               
                if (hit.transform != transform && !hit.transform.IsChildOf(transform))
                {
                    return false; 
                }
            }

            
            return true;
        }

        return false;
    }
}