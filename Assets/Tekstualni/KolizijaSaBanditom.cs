using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KolizijaSaBanditom : MonoBehaviour
{

    CharacterController characterController;

    bool kolizijaSeDesila = false;

    private void Update()
    {
        if(kolizijaSeDesila && Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Zapocni konverzaciju sa banditom");
            var dugmeZaDijalog = GameObject.Find("TestButton").GetComponent<Button>();
            dugmeZaDijalog.onClick.Invoke();

            //zakljucaj rotaciju misa
            MouseCamLook.zakociRotacijuMisa = true;

            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Objekat kolizije je: " + collision.gameObject.name);
        if (collision.gameObject.name == "Capsule")
        {
            kolizijaSeDesila = true;                        
        }
        else
        {
            kolizijaSeDesila = false;
        }
    }
}
