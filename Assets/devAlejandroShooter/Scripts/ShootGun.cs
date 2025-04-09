using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

namespace devAlejandroShooter.Scripts
{
    public class ShootGun : MonoBehaviour
    {
        public Transform firePoint;
        public float fireDistance = 50f;
        public LayerMask hitLayers;
        public LineRenderer laserLine; 
        public float laserDuration = 0.05f;

        private XRGrabInteractable grabInteractable;

        private void Awake()
        {
            grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.activated.AddListener(OnActivate);
        }

        private void OnDestroy()
        {
            grabInteractable.activated.RemoveListener(OnActivate);
        }

        private void OnActivate(ActivateEventArgs args)
        {
            Fire();
        }

        private void Fire()
        {
            Vector3 endPoint = firePoint.position + firePoint.forward * fireDistance;

            if (Physics.Raycast(firePoint.position, firePoint.forward, out RaycastHit hit, fireDistance, hitLayers))
            {
                endPoint = hit.point;

                var target = hit.collider.GetComponent<devAlejandroShooter.Scripts.ReceiveShoot>();
                if (target != null)
                {
                    target.HandleShoot();
                }
            }

            if (laserLine != null)
            {
                StartCoroutine(ShowLaser(firePoint.position, endPoint));
            }
        }

        private IEnumerator ShowLaser(Vector3 start, Vector3 end)
        {
            laserLine.SetPosition(0, start);
            laserLine.SetPosition(1, end);
            laserLine.enabled = true;

            yield return new WaitForSeconds(laserDuration);

            laserLine.enabled = false;
        }
    }
}