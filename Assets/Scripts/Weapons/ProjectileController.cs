using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
    {
        // --- Config ---
        public float speed = 100;
        public float radius = 20;
        public float force = 50;
        public LayerMask collisionLayerMask;

        // --- Explosion VFX ---
        public GameObject rocketExplosion;

        // --- Projectile Mesh ---
        public MeshRenderer projectileMesh;

        // --- Script Variables ---
        private bool targetHit;

        // --- Audio ---
        public AudioSource inFlightAudioSource;

        // --- VFX ---
        public GameObject disableOnHit;


        private void Update()
        {
            // --- Check to see if the target has been hit. We don't want to update the position if the target was hit ---
            if (targetHit) return;

            // --- moves the game object in the forward direction at the defined speed ---
            transform.position += transform.forward * (speed * Time.deltaTime);
        }


        /// <summary>
        /// Explodes on contact.
        /// </summary>
        /// <param name="collision"></param>
        private void OnCollisionEnter(Collision collision)
        {
            // --- return if not enabled because OnCollision is still called if compoenent is disabled ---
            if (!enabled) return;

            // --- Explode when hitting an object and disable the projectile mesh ---
            Explode();
            projectileMesh.enabled = false;
            targetHit = true;
            inFlightAudioSource.Stop();
            foreach(Collider col in GetComponents<Collider>())
            {
                col.enabled = false;
            }
            disableOnHit.SetActive(false);


            // --- Destroy this object after 2 seconds. Using a delay because the particle system needs to finish ---
            Destroy(gameObject, 5f);
        }


        /// <summary>
        /// Instantiates an explode object.
        /// </summary>
        private void Explode()
        {
            // --- Instantiate new explosion option. I would recommend using an object pool ---
            GameObject newExplosion = Instantiate(rocketExplosion, transform.position, rocketExplosion.transform.rotation, null);

            Collider[] blocks = Physics.OverlapSphere(transform.position, radius);

            foreach (var block in blocks) 
            {
                if (block.TryGetComponent(out BarrierImpact impact))
                {
                    impact.ActiveParts();
                }
                else if(block.TryGetComponent(out Enemy enemy))
                {
                    enemy.Die?.Invoke();
                    enemy.AddExplosionForce?.Invoke();
                }
                
                if (block.TryGetComponent(out Rigidbody rigidbody))
                {
                    Vector3 direction = block.transform.position - transform.position;
            
                    rigidbody.AddForce(direction * force, ForceMode.Impulse);
                }
            }
        }
    }