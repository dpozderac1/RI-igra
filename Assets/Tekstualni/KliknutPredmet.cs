using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KliknutPredmet : MonoBehaviour
{
    public Sprite slikaBone;
    private static bool otvorenaVrata = false;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera kamera = GameObject.Find("Camera").GetComponent<Camera>();
            Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (!otvorenaVrata && hit.transform.name == "Basement Door Left" && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta,"KljucUTamnici")!=-1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "KljucUTamnici")==InventorySkripta.indeksKliknutogDugmeta)
                {                    
                    GameObject gObject = GameObject.Find(hit.transform.name);
                    iTween.RotateBy(gObject, iTween.Hash("z", 0.35f, "time", 4f));
                    //iTween.RotateUpdate(gObject, iTween.Hash("z", 0.1f, "islocal", false,"time", 0.5f));
                    otvorenaVrata = !otvorenaVrata;
                }
                if (hit.transform.name == "BoneUTamnici")
                {
                    GameObject gObject= GameObject.Find(hit.transform.name);
                    Destroy(gObject);
                    GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(slikaBone,"BoneUTamnici");
                }
            }
        }
    }
}
