using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float throwForce = 10f;
    public GameObject throwObjPrefab;
    public Transform throwNode;
    public FireArm fireArm;
    private Camera FPSCamera;

    // Start is called before the first frame update
    void Start()
    {
        FPSCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2")){
            Throw();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Throw()
    {
        GameObject obj = Instantiate(throwObjPrefab,throwNode.position,Quaternion.identity);
        obj.GetComponent<Rigidbody>().AddForce(FPSCamera.transform.forward * throwForce);
    }

    public void Shoot(){

        if(fireArm != null)
        {
           fireArm.Fire(); 
        }
        else
        {
            print("Asetta ei ole asetettu");
        }
    }

    public void SetFireArm(FireArm newFirearm){
        fireArm = newFirearm;
    }
}
