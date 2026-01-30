using UnityEngine;

public class WinPlace : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.WinGame();
        }
    }
}
