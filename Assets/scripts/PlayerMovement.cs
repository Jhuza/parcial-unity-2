using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 5f;
    public Animator animator;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(x, 0f, z);

        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World);
        float speed = movimiento.magnitude;
        animator.SetFloat("speed", speed);
    }
}