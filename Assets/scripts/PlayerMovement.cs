using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float velocidad = 5f;
    public Animator animator;

    

    public Transform modelo;
    public float rotationSpeed = 10f;


    void Update()
    
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 movimiento = new Vector3(x, 0f, z);

        
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.Self);

        // Mover al jugador en coordenadas globales
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World);

        // Rotar solo el modelo
        if (movimiento != Vector3.zero)
        {
            Quaternion rotacionObjetivo = Quaternion.LookRotation(movimiento);
            modelo.rotation = Quaternion.Slerp(modelo.rotation, rotacionObjetivo, rotationSpeed * Time.deltaTime);
        }

        // Animación

        float speed = movimiento.magnitude;
        animator.SetFloat("speed", speed);
    }
}