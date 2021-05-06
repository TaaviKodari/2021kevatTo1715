using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyInteract : MonoBehaviour, IInteractable
{
    public float pushForce = 10;
    Rigidbody rigidbody;

    public void Interact()
    {
        rigidbody.AddForce(Camera.main.transform.forward * pushForce, ForceMode.Impulse); 
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
