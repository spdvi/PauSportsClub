using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace devAlejandroShooter.Scripts
{
    public class FullAutoShoot : MonoBehaviour
    {
        public float fireRate = 0.1f; // tiempo entre disparos (10 disparos por segundo)

        private ShootGun shootGun;
        private XRGrabInteractable grabInteractable;
        private Coroutine shootingCoroutine;

        private void Awake()
        {
            shootGun = GetComponent<ShootGun>();
            grabInteractable = GetComponent<XRGrabInteractable>();

            if (grabInteractable != null)
            {
                grabInteractable.activated.AddListener(OnActivate);
                grabInteractable.deactivated.AddListener(OnDeactivate);
            }
        }

        private void OnDestroy()
        {
            if (grabInteractable != null)
            {
                grabInteractable.activated.RemoveListener(OnActivate);
                grabInteractable.deactivated.RemoveListener(OnDeactivate);
            }
        }

        private void OnActivate(ActivateEventArgs args)
        {
            if (shootingCoroutine == null)
            {
                shootingCoroutine = StartCoroutine(AutoFire());
            }
        }

        private void OnDeactivate(DeactivateEventArgs args)
        {
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
            }
        }

        private IEnumerator AutoFire()
        {
            while (true)
            {
                shootGun.SendMessage("Fire");
                yield return new WaitForSeconds(fireRate);
            }
        }
    }
}
