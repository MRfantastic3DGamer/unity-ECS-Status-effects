using UnityEngine;
using UnityEngine.Events;

namespace Projectile
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : MonoBehaviour
    {
        public int damage;
        public GameObject hitLocationEffectObject;
        public delegate void Ghost(Projectile projectile);
        public event Ghost CollisionInform;
        
        protected Rigidbody rigidbody;
        protected bool targetHit;
        protected LineRenderer LineRenderer;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            LineRenderer = GetComponent<LineRenderer>();
        }

        public abstract void OnThrow();
        public abstract void OnCollision(Collision collision);
        private void OnCollisionEnter(Collision collision)
        {
            CollisionInform?.Invoke(this);
            OnCollision(collision);
            if (targetHit)
                return;
            targetHit = true;
            //TODO: check if you hit an enemy
        }
    }
}