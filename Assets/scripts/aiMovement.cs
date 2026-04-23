using UnityEngine;
using UnityEngine.AI;

public class aiMovement : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        if (animator != null)
            animator.applyRootMotion = false;

        Debug.Log("¿Está en NavMesh? " + agent.isOnNavMesh);
    }

    void Update()
    {
        if (agent == null || !agent.isOnNavMesh || target == null) return;

        agent.SetDestination(target.position);

        // Solo setea el float si el parámetro existe en el Animator
        if (animator != null && AnimatorHasParameter("velocidad", animator))
        {
            float speed = agent.velocity.magnitude;
            animator.SetFloat("velocidad", speed);
        }
    }

    bool AnimatorHasParameter(string paramName, Animator anim)
    {
        foreach (AnimatorControllerParameter param in anim.parameters)
        {
            if (param.name == paramName) return true;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("tocó al jugador, -10 segundos");

            if (animator != null) animator.SetBool("ataque", true);
            agent.isStopped = true;

            GameManager.instance.RestarTiempo(10f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (animator != null) animator.SetBool("ataque", false);
            agent.isStopped = false;
        }
    }
}