using UnityEngine;

public class ClayAutodestruction : MonoBehaviour
{


    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
