using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pick();
        }
    }

    protected virtual void Pick()
    {
        Destroy(gameObject);
    }
}
