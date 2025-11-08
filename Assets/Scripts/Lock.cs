using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool canOpen = false;
    public Door[] doors;
    public KeyColor keyColor;
    public bool isLocked = true;
    Animator key;

    void Start()
    {
        key = GetComponent<Animator>();
    }

    void Update()
    {
        Debug.Log("isLocked: " + isLocked + ", canOpen: " + canOpen);
        
        if (Input.GetKeyDown(KeyCode.E) && canOpen && isLocked)
        {
            key.SetBool("useKey", CheckTheKey());
        }
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
        if (GameManager.instance.redKeys > 0 && keyColor == KeyColor.Red)
        {
            GameManager.instance.redKeys--;

            isLocked = false;
            return true;
        }
        else if (GameManager.instance.greenKeys > 0 && keyColor == KeyColor.Green)
        {
            GameManager.instance.greenKeys--;

            isLocked = false;
            return true;
        }
        else if (GameManager.instance.goldKeys > 0 && keyColor == KeyColor.Gold)
        {
            GameManager.instance.goldKeys--;

            isLocked = false;
            return true;
        }
        else
        {
            Debug.Log("Nie masz klucza!");
            return true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
            Debug.Log("You can open the door now!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
            Debug.Log("You can not open the door :(");
        }
    }
}