using System.Net.Sockets;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool canOpen = false;
    public Door[] doors;
    public KeyColor color;
    bool isLockUsed = false;
    Animator key;

    void Start()
    {
        key = GetComponent<Animator>();
    }

    public void UseKey()
    {
        foreach (Door door in doors)
        {
            door.Open();
        }
    }

    public bool CheckTheKey()
    {
        if (GameManager.instance.redKeys > 0 && color == KeyColor.Red)
        {
            GameManager.instance.redKeys--;
            isLockUsed = true;
            return true;
        }
        else if (GameManager.instance.greenKeys > 0 && color == KeyColor.Green)
        {
            GameManager.instance.greenKeys--;
            isLockUsed = true;
            return true;
        }
        else if (GameManager.instance.goldKeys > 0 && color == KeyColor.Gold)
        {
            GameManager.instance.goldKeys--;
            isLockUsed = true;
            return true;
        }
        else
        {
            Debug.Log("Nie masz klucza!");
            return false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen && !isLockUsed)
        {
            key.SetBool("useKey", CheckTheKey());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
            Debug.Log("Trigger enter - doors");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
            Debug.Log("Trigger exit - doors");
        }
    }

    
}
