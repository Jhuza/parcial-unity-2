using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float tiempo = 60f;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        tiempo -= Time.deltaTime;

        if (tiempo <= 0)
        {
            tiempo = 0;
            Debug.Log("Se acabó el tiempo");
            Time.timeScale = 0f;
        }
    }

    public void RestarTiempo(float cantidad)
    {
        tiempo -= cantidad;

        if (tiempo < 0)
            tiempo = 0;

        Debug.Log("Tiempo restante: " + tiempo);
    }

    public void AñadirTiempo(float cantidad)
    {
        tiempo += cantidad;

        if (tiempo < 0)
            tiempo = 0;

        Debug.Log("Tiempo restante: " + tiempo);
    }
}