using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoMonedas;

    void Start()
    {
        // Suscribirse a los eventos del GameManager
        GameManager.instance.onTiempoChanged += ActualizarTiempo;
        GameManager.instance.onMonedasChanged += ActualizarMonedas;

        // Mostrar valores iniciales
        ActualizarTiempo(GameManager.instance.tiempo);
        ActualizarMonedas(GameManager.instance.monedas);
    }

    void OnDestroy()
    {
        // Desuscribirse para evitar errores
        if (GameManager.instance != null)
        {
            GameManager.instance.onTiempoChanged -= ActualizarTiempo;
            GameManager.instance.onMonedasChanged -= ActualizarMonedas;
        }
    }

    void ActualizarTiempo(float tiempo)
    {
        // Muestra el tiempo en formato 0:00
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        textoTiempo.text = $"Tiempo restante: {minutos}:{segundos:00}";

        // Cambia a rojo si quedan menos de 10 segundos
        textoTiempo.color = tiempo <= 10f ? Color.red : Color.white;
    }

    void ActualizarMonedas(int monedas)
    {
        textoMonedas.text = $"Chupiplus: {monedas}";
    }
}