using UnityEngine;

public class Moneda : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Es el jugador");
            Destroy(gameObject);
            GameManager.instance.AñadirMoneda(); // Suma moneda al contador
            GameManager.instance.AñadirTiempo(10f); // Y también añade tiempo
        }
    }
}