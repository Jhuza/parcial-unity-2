using UnityEngine;
using UnityEngine.AI;

public class aiMovement : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    [Header("Velocidad")]
    public float velocidadInicial = 3.5f;
    public float velocidadMaxima = 10f;
    public float tasaAumento = 0.5f;  // Cuánto aumenta por segundo

    [Header("Configuración")]
    public float tiempoCooldown = 2f;
    private float cooldownTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = velocidadInicial;
    }

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        // Aumenta la velocidad con el tiempo, sin pasar el máximo
        agent.speed = Mathf.Min(agent.speed + tasaAumento * Time.deltaTime, velocidadMaxima);

        agent.destination = target.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && cooldownTimer <= 0f)
        {
            Debug.Log("tocó al jugador, -10 segundos");
            GameManager.instance.RestarTiempo(10f);
            cooldownTimer = tiempoCooldown;
        }
    }
}