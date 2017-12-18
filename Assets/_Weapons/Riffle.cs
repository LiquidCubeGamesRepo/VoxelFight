﻿using UnityEngine;

namespace Weapons { 

    /// <summary>
    /// Riffle weapon.
    /// </summary>
    public class Riffle : Weapon
    {
        public override void Shoot()
        {
            AddDispersion ();

            MuzzleEffect ();

            GameObject bulet = Instantiate (bullet, gunEndPoint.position, Quaternion.identity) as GameObject;
            var proj = bulet.GetComponent<Projectile> ();
            proj.SetDamage (damage);
            proj.SetDestroyRange (range);
            proj.SetShooter (this.gameObject);
            proj.GetComponent<Rigidbody> ().velocity = gunEndPoint.forward * bulletSpeed;

        }

        private void AddDispersion()
        {
            //ADD Dispersion
            gunEndPoint.localRotation = Quaternion.identity; //reset transform
            int n = UnityEngine.Random.Range (-dispersion, dispersion); //random dispersion for weapon
            gunEndPoint.RotateAround (gunEndPoint.position, gunEndPoint.up, n);
        }

        private void MuzzleEffect()
        {
            GameObject muzzle2 = Instantiate (muzzle, gunEndPoint) as GameObject;
            Destroy (muzzle2, 0.15f);
        }
    }
}
