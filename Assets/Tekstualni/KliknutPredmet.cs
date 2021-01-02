using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KliknutPredmet : MonoBehaviour
{
    public Sprite slikaBone;
    public Sprite slikaKljuca;
    private static bool otvorenaVrata = false;

    bool otvoriVrataPoredPrekidaca = false;
    int[] prekidaciPoredVrata= { 0, 0, 0 };

    public GameObject svijecaNaStolu;
    
    
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

                if(hit.transform.name== "KljucUTamnici" && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "BoneUTamnici") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "BoneUTamnici") == InventorySkripta.indeksKliknutogDugmeta)
                {
                    GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(slikaKljuca, "KljucUTamnici");
                    Destroy(GameObject.Find("KljucUTamnici"));
                }

                if (hit.transform.name== "PrekidaciPoredVrata1")
                {
                    prekidaciPoredVrata[0]++;
                    if (prekidaciPoredVrata[0] > 9)
                    {
                        prekidaciPoredVrata[0] = 0;
                    }
                    GameObject.Find("brojMacevaText1").GetComponent<TMP_Text>().text=prekidaciPoredVrata[0].ToString();
                }

                if (hit.transform.name == "PrekidaciPoredVrata2")
                {
                    prekidaciPoredVrata[1]++;
                    if (prekidaciPoredVrata[1] > 9)
                    {
                        prekidaciPoredVrata[1] = 0;
                    }
                    GameObject.Find("brojMacevaText2").GetComponent<TMP_Text>().text = prekidaciPoredVrata[1].ToString();
                }

                if (hit.transform.name == "PrekidaciPoredVrata3")
                {
                    prekidaciPoredVrata[2]++;
                    if (prekidaciPoredVrata[2] > 9)
                    {
                        prekidaciPoredVrata[2] = 0;
                    }
                    GameObject.Find("brojMacevaText3").GetComponent<TMP_Text>().text = prekidaciPoredVrata[2].ToString();
                }


                if (hit.transform.name == "Table_Small_Za_Svijecu" && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "SvijecaPredmet") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "SvijecaPredmet") == InventorySkripta.indeksKliknutogDugmeta)
                {
                    //prikazi svijecu
                    svijecaNaStolu.SetActive(true);

                    //postavi tekst u pismo
                    GameObject.Find("TekstPisma").GetComponent<TMP_Text>().text="Tekst pisma";
                }
            }
        }

        if (!otvoriVrataPoredPrekidaca && prekidaciPoredVrata[0] == 2 && prekidaciPoredVrata[1] == 3 && prekidaciPoredVrata[2] == 3)
        {
            GameObject gObject = GameObject.Find("DoorGate_Wooden_Right_Za_Otvaranje");
            iTween.RotateBy(gObject, iTween.Hash("z", -0.35f, "time", 4f));
            otvoriVrataPoredPrekidaca = true;
        }        

        //zacuje se buka
        if(System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "SvijecaPredmet") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "BoneUTamnici") != -1)
        {
            PomjeriVikinga.trebaTrcati = true;
        }
    }
}
