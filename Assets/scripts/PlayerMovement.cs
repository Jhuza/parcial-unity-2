using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadMaxima = 15f; // Para que el boost tenga límite
    public Animator animator;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(x, 0f, z);

        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.Self);

        float speed = movimiento.magnitude;
        animator.SetFloat("speed", speed);
    }

    public void AumentarVelocidad(float cantidad)
    {
        velocidad = Mathf.Min(velocidad + cantidad, velocidadMaxima);
    }
}