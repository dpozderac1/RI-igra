using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KliknutPredmetNivo3 : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition, closedPosition, openRotate, closedRotate;

    private Hashtable iTweenArgs, iTweenArgsRotate;

    // Start is called before the first frame update
    void Start()
    {
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", openPosition);
        iTweenArgs.Add("time", 1);
        iTweenArgs.Add("islocal", true);

        iTweenArgsRotate = iTween.Hash();
        iTweenArgsRotate.Add("rotation", openRotate);
        iTweenArgsRotate.Add("time", 1);
        iTweenArgsRotate.Add("islocal", true);
    }

    // Update is called once per frame
    void Update()
    {
        Camera kamera = GameObject.Find("Camera_high").GetComponent<Camera>();
        Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Klik");
                if (hit.transform.name == "Koliba vrata" && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZlatniKljuc") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZlatniKljuc") == InventorySkripta.indeksKliknutogDugmeta)
                {
                    Debug.Log("Klik1");
                    GameObject gObject = GameObject.Find(hit.transform.name);
                    iTween.MoveTo(gObject, iTweenArgs);
                    iTween.RotateTo(gObject, iTweenArgsRotate);

                }

            }
        }
    }
}
