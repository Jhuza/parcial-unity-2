using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackHitbox;
    public float attackDuration = 0.3f;
    public Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
        StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine()
    {
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackHitbox.SetActive(false);
    }
}