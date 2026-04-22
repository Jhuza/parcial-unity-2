using UnityEngine;

public class winCondition : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
{
    Debug.Log(other.name);
    Debug.Log(other.tag);

    if (other.CompareTag("Player"))
    {
        Debug.Log("Ganaste");
        Time.timeScale = 0f;
    }
}
}
