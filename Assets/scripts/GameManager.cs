using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float tiempo = 60f;
    public int monedas = 0;

    public System.Action<float> onTiempoChanged;
    public System.Action<int> onMonedasChanged;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        tiempo -= Time.deltaTime;
        onTiempoChanged?.Invoke(tiempo);

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
        if (tiempo < 0) tiempo = 0;

        onTiempoChanged?.Invoke(tiempo);
        Debug.Log("Tiempo restante: " + tiempo);
    }

    public void AñadirTiempo(float cantidad)
    {
        tiempo += cantidad;
        onTiempoChanged?.Invoke(tiempo);
        Debug.Log("Tiempo restante: " + tiempo);
    }

    public void AñadirMoneda()
    {
        monedas++;
        onMonedasChanged?.Invoke(monedas);
        Debug.Log("Monedas: " + monedas);
    }
}