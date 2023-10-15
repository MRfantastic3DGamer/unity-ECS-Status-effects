using System;
using KinematicCharacterController.Examples;
using UnityEngine;

namespace Projectile
{
    public class ProjectileController : MonoBehaviour
    {
        [Space]
        [Header("References")]
        public Transform cam;
        public Transform throwPoint;
        public GameObject objectToThrow;
        public UseHeldItems heldItems;

        [Space]
        [Header("Settings")]
        public float throwWait;

        [Space]
        [Header("Throwing")]
        public float throwForce;
        public float throwUpwardForce;

        [Space] [Header("HitSimulation")] 
        public bool debugSimulation;
        public float hitSimulationRange;
        
        private ExampleCharacterController _character;
        private float _timeToThrow = 0f;
        private bool _throwInputHold;
        private bool _throwOnRelease;

        private Vector3 _ghostProjectileHitPosition;
        private GameObject _hitLocationEffectObject;
        
        private void Start()
        {
            _character = GetComponentInParent<ExampleCharacterController>();
            _throwInputHold = true;
        }
        
        public void SetInput(bool b)
        {
            if (b)
            {
                _throwInputHold = b;
                _timeToThrow += Time.deltaTime;
            }
            else if(_timeToThrow > throwWait)
            {
                if(CanThrowCheck())
                    Throw(objectToThrow, false);
            }
        }

        private bool CanThrowCheck()
        {
            return heldItems.UseHeld(ref objectToThrow);
        }

        private void Throw(GameObject objectToThrow, bool isGhost)
        {
            _timeToThrow = 0;
            _throwInputHold = false;
            _throwOnRelease = false;
            Projectile projectile = Instantiate(objectToThrow, throwPoint.position, throwPoint.rotation).GetComponent<Projectile>();
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            Vector3 forceDirection = cam.forward;
            Vector3 forceToAdd = forceDirection * throwForce + _character.transform.up * throwUpwardForce;
            projectileRb.velocity = GetComponentInParent<Rigidbody>().velocity;
            projectileRb.AddForce(forceToAdd, ForceMode.Impulse);
            projectile.OnThrow();
            if (isGhost)
                projectile.CollisionInform += ghostInform;
        }

        private void ghostInform(Projectile projectile)
        {
            _ghostProjectileHitPosition = projectile.transform.position;
        }
        
        private void OnDrawGizmos()
        {
            if (debugSimulation)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(transform.position, hitSimulationRange);
            }
        }
    }
}