using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoMonedas;

    void Start()
    {

        GameManager.instance.onTiempoChanged += ActualizarTiempo;
        GameManager.instance.onMonedasChanged += ActualizarMonedas;

        ActualizarTiempo(GameManager.instance.tiempo);
        ActualizarMonedas(GameManager.instance.monedas);
    }

    void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.onTiempoChanged -= ActualizarTiempo;
            GameManager.instance.onMonedasChanged -= ActualizarMonedas;
        }
    }

    void ActualizarTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        textoTiempo.text = $"Tiempo restante: {minutos}:{segundos:00}";

        textoTiempo.color = tiempo <= 10f ? Color.red : Color.white;
    }

    void ActualizarMonedas(int monedas)
    {
        textoMonedas.text = $"Chupiplus: {monedas}";
    }
}