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

    //1.4. asiat
     public Transform weaponNode;

     public List<Transform> firearms = new List<Transform>();
    private Camera FPSCamera;
    public int currentWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        FPSCamera = Camera.main;
         //1.4. asiat
         foreach(Transform child in weaponNode)
         {
            if(child.GetComponent<FireArm>())
            {
                firearms.Add(child);
            }
         }

        UpdateCurrentweapon();
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
    //1.4. asiat
         if(Input.GetKeyDown(KeyCode.Q))
         {
             ChangeNextWeapon(1);
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

        //firearms[currentWeaponIndex].GetComponent<FireArm>()
    }

    public void SetFireArm(FireArm newFirearm){
        fireArm = newFirearm;
    }
    //1.4. asiat
     public void ChangeNextWeapon(int nextIndex)
     {
         currentWeaponIndex += nextIndex;

        if(currentWeaponIndex > firearms.Count-1)
        {
            currentWeaponIndex = 0;
        }

         UpdateCurrentweapon();
     }
    //1.4. asiat
    public void UpdateCurrentweapon()
    {
        for(int i = 0; i < firearms.Count;i++)
        {
            if(currentWeaponIndex != i)
            {
                firearms[i].gameObject.SetActive(false);
            }
            else
             {
                firearms[i].gameObject.SetActive(true);
                fireArm = firearms[i].GetComponent<FireArm>();
                Journal.Instance.Log(fireArm.weaponName);
             }
        }
    }
}
