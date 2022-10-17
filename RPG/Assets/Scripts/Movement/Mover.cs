
using UnityEngine;

namespace RPG.Movement
{
    
    [RequireComponent(typeof(Rigidbody))]
    public class Mover : MonoBehaviour
    {
        public Transform bodyTransform= null;
        public float rotationSpeed = 30f;
        Rigidbody rb = null;
        Animator anim = null;
        bool isMoving = false;
        private void Start(){
            anim = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 _dir,float _speed){
            _dir = _dir.normalized;
            isMoving = Mathf.Abs(_dir.magnitude) > 0.1f;
            rb.velocity = _dir * _speed;
            if (bodyTransform == null)  return;
            if (isMoving){
                bodyTransform.localRotation = 
                Quaternion.Slerp(bodyTransform.localRotation, Quaternion.LookRotation(_dir), rotationSpeed *Time.deltaTime);
            }

        }

        public void HandleAnimation(){
            if (anim == null) return;
            anim.SetBool("isMoving", isMoving);
        }

        public void Stop(){
            rb.velocity = Vector2.zero;

        }

        
    }

}