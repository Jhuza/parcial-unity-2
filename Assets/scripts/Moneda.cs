using UnityEngine;

public class Moneda : MonoBehaviour
{
    public AudioClip sonidoMoneda;
    public float boostVelocidad = 1f; // Cuánta velocidad añade cada moneda

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Es el jugador");

            // Aumenta la velocidad del jugador
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            if (pm != null)
            {
                pm.AumentarVelocidad(boostVelocidad);
            }

            // Reproduce el sonido antes de destruir el objeto
            if (sonidoMoneda != null)
            {
                AudioSource.PlayClipAtPoint(sonidoMoneda, transform.position);
            }

            GameManager.instance.AñadirTiempo(10f);
            Destroy(gameObject);
        }
    }
}