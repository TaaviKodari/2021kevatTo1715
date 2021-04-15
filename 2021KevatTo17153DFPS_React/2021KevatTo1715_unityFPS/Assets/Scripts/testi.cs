using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testi : MonoBehaviour, ITakeDamage<float>, IDie, IInteractable
{
    public float health = 5;
    bool isAlive = true;
    public void Damage(float Damage)
    {
        if(!isAlive)
        {
            return;
        }

        health = Mathf.Max(health-Damage,0);

        if(health <= 0)
        {
            isAlive = false;
            Die();
        }

        print($"otin vahinkoa: {Damage} terveisin {gameObject.name}");
    }

    public void Die()
    {
        //tee tässä vaiheessa kuolemis effektit ja animaatio jne
        DestroyObj();
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage()
    {
        print("Ai minuun osui ;_;");
    }
}
