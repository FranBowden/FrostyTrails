using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SnowmanMovement : MonoBehaviour
{
    public Animator animator;

    //private SnowmanAnimatorManager animatorManager;
    private NavMeshAgent agent;

    [SerializeField] private float boundaryBuffer = 0.5f;
    [SerializeField] private float destinationThreshold = 1f;

    private Vector3 navMeshBoundsMin;
    private Vector3 navMeshBoundsMax;
    private void Start()
    {
        StartCoroutine("Jump");


        agent = GetComponent<NavMeshAgent>();
        //  animatorManager = GetComponent<SnowmanAnimatorManager>();

        MeshFilter navMeshMesh = GetComponent<MeshFilter>();
        if (navMeshMesh != null)
        {
            navMeshBoundsMin = navMeshMesh.mesh.bounds.min + transform.position;
            navMeshBoundsMax = navMeshMesh.mesh.bounds.max + transform.position;
        }

        SetRandomDestination();


        /*
        if(animatorManager != null)
        {
            StartCoroutine("Jump");
        } else
        {
            Debug.Log("Cannot find animator Manager Script");
        }*/

    }

    private void Update()
    {

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            SetRandomDestination();
        }
    }

    void SetRandomDestination()
    {
        Vector3 randomPoint = GetRandomPointInBounds();
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10f, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
    Vector3 GetRandomPointInBounds()
    {
        float randomX = Random.Range(navMeshBoundsMin.x + boundaryBuffer, navMeshBoundsMax.x - boundaryBuffer);
        float randomZ = Random.Range(navMeshBoundsMin.z + boundaryBuffer, navMeshBoundsMax.z - boundaryBuffer);

        return new Vector3(randomX, 0, randomZ);
    }

    IEnumerator Jump()
    {
        animator.SetBool("Jump", true);
        yield return new WaitForSeconds(.5f);
    }
}
