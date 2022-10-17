
using UnityEngine;
using UnityEngine.Events;
public class Combat : MonoBehaviour{
    public float attackRadius = 1.5f;
    public Vector3 offset = Vector3.zero;
    public int damage = 7;
    public UnityEvent combatActions;
    public bool isAttacking = false;
    Animator anim;

    private void Start(){
        anim = GetComponent<Animator>();
        combatActions.Invoke();
    }
    public void Attack(){
        //play attack animation
        isAttacking = true;
        anim.SetTrigger("attack");
        
    }
    public void DealDamage(){
        Collider[] targets = Physics.OverlapSphere(transform.position + offset, attackRadius);
        foreach (Collider t in targets){
            Health h = t.GetComponent<Health>();
            if (h == null) continue;
            h.GetDamage(damage);
        }

    }
    public void OnAttackExit(){
        this.isAttacking = false;
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position+offset, attackRadius);
        
    }

    
}
