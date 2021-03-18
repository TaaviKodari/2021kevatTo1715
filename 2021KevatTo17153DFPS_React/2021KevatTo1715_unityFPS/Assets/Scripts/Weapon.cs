using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float throwForce = 10f;
    public GameObject throwObjPrefab;
    private Camera FPSCamera;

    // Start is called before the first frame update
    void Start()
    {
        FPSCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Throw();
        }
    }

    private void Throw()
    {
     GameObject obj = Instantiate(throwObjPrefab,transform.position,Quaternion.identity);
     obj.GetComponent<Rigidbody>().AddForce(FPSCamera.transform.forward * throwForce);
    }
}
