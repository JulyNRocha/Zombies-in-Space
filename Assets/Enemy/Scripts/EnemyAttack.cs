using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damagePerHit = 20f;
    
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }
    
    public void AttackHitEvent()
    {
        if (target == null) return;
        target.TakeDamage(damagePerHit);
    }

}
