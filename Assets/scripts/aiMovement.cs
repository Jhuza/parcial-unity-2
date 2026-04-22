using UnityEngine;
using UnityEngine.AI;

public class aiMovement : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.position;
    }

    void OnTriggerEnter(Collider other)
{
    Debug.Log(other.name);
    Debug.Log(other.tag);

    if (other.CompareTag("Player"))
    {
        Debug.Log("tocó al jugador, -10 segundos");
        GameManager.instance.RestarTiempo(10f);     
    }
}
}
