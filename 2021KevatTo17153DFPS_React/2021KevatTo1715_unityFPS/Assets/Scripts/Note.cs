using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    
    [Header("Tähän teksti minkä pelaaja voi lukea")]
    [TextArea(4,8)]
    public string noteText = "";
    public void Interact()
    {
        Journal.Instance.Log(noteText);
    }

}
