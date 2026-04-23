using UnityEngine;

public class Moneda : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Es el jugador");
            Destroy(gameObject);
            GameManager.instance.AñadirMoneda();
            GameManager.instance.AñadirTiempo(10f);
        }
    }
}