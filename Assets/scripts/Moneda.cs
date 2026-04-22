using UnityEngine;

public class Moneda : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
{
    Debug.Log(other.name);
    Debug.Log(other.tag);

    if (other.CompareTag("Player"))
    {
        Debug.Log("Es el jugador");
        Destroy(gameObject);
        GameManager.instance.AñadirTiempo(10f);
    }
}
}