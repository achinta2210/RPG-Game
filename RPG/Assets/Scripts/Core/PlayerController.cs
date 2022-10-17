using RPG.Movement;

using UnityEngine;

namespace RPG.Core {

    public class PlayerController : MonoBehaviour{
        public float speed = 0.5f;
        Vector3 inputVector;
        Mover mover;
        Combat combat;

        private void Start(){
            mover = GetComponent<Mover>();
            combat = GetComponent<Combat>();
        }
        private void Update()
        {
            inputVector.x = Input.GetAxisRaw("Horizontal");
            inputVector.z = Input.GetAxisRaw("Vertical");
            if (combat.isAttacking) return;
            HandleMovement();
            if (Input.GetMouseButtonDown(0)){
                mover.Stop();
                combat.Attack();
            }
        }

        void HandleMovement(){
            if (inputVector.z == 0){
                mover.Move(inputVector, speed);
            }
            if (inputVector.x == 0){
                mover.Move(inputVector, speed);
            }
            mover.HandleAnimation();
        }

        

    }
}

