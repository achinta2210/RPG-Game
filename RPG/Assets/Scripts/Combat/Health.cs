
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int startingHealth = 10;
    int currentHealth;
    public UnityEvent onDeath;
    public bool isDead { get; private set; }
    private void Start(){
        currentHealth = startingHealth;
        
    }

    public void GetDamage(int _damage){
        if (isDead) return;
        currentHealth = Mathf.Max(0, currentHealth - _damage);
        if (currentHealth == 0){
            Die();
        }
    }

    void Die(){
        isDead = true;
        onDeath.Invoke();
    }

}
