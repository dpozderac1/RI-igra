using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KliknutPredmet : MonoBehaviour
{
    public Sprite slikaBone;
    public Sprite slikaKljuca;
    public Sprite zutaPosudaSlika;
    public Sprite zelenaPosudaSlika;
    public Sprite maliVrcSlika;
    public Sprite slikaZlatnogKljuca;

    private static bool otvorenaVrata = false;

    bool otvoriVrataPoredPrekidaca = false;
    int[] prekidaciPoredVrata = { 0, 0, 0 };

    public GameObject svijecaNaStolu;

    bool dodanaZuta = false;
    bool dodanaZelena = false;

    public AudioSource audioSource;
    public AudioClip sipanjeTekucine;

    public GameObject efekat;

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
                if (!otvorenaVrata && hit.transform.name == "Basement Door Left" && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "KljucUTamnici") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "KljucUTamnici") == InventorySkripta.indeksKliknutogDugmeta)
                {
                    GameObject gObject = GameObject.Find(hit.transform.name);
                    iTween.RotateBy(gObject, iTween.Hash("z", 0.35f, "time", 4f));
                    //iTween.RotateUpdate(gObject, iTween.Hash("z", 0.1f, "islocal", false,"time", 0.5f));
                    otvorenaVrata = !otvorenaVrata;
                }
                if (hit.transform.name == "BoneUTamnici")
                {
                    GameObject gObject = GameObject.Find(hit.transform.name);
                    Destroy(gObject);
                    GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(slikaBone, "BoneUTamnici");
                }

                if (hit.transform.name == "KljucUTamnici" && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "BoneUTamnici") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "BoneUTamnici") == InventorySkripta.indeksKliknutogDugmeta)
                {
                    GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(slikaKljuca, "KljucUTamnici");
                    Destroy(GameObject.Find("KljucUTamnici"));
                }

                if (hit.transform.name == "PrekidaciPoredVrata1")
                {
                    prekidaciPoredVrata[0]++;
                    if (prekidaciPoredVrata[0] > 9)
                    {
                        prekidaciPoredVrata[0] = 0;
                    }
                    GameObject.Find("brojMacevaText1").GetComponent<TMP_Text>().text = prekidaciPoredVrata[0].ToString();
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
                    GameObject.Find("TekstPisma").GetComponent<TMP_Text>().text = "Alhemičarski recept:\n\nSpoji boje tako da tvore narandžastu prije nego što dodaš malo zelene.";
                }

                //alhemicarska zagonetka
                if (System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZutaPosuda") != -1 &&
                    System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZutaPosuda") == InventorySkripta.indeksKliknutogDugmeta &&
                    hit.transform.name == "MaliVrc")
                {
                    dodanaZuta = true;
                    audioSource.PlayOneShot(sipanjeTekucine);

                    if (dodanaZelena)
                    {
                        GameObject gObject = GameObject.Find("MaliVrc");
                        Destroy(gObject);
                        GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(maliVrcSlika, "MaliVrc");
                    }
                }

                if (System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZelenaPosuda") != -1 &&
                    System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZelenaPosuda") == InventorySkripta.indeksKliknutogDugmeta &&
                    hit.transform.name == "MaliVrc")
                {
                    dodanaZelena = true;
                    audioSource.PlayOneShot(sipanjeTekucine);

                    if (dodanaZuta)
                    {
                        GameObject gObject = GameObject.Find("MaliVrc");
                        Destroy(gObject);
                        GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(maliVrcSlika, "MaliVrc");
                    }
                }

                if (hit.transform.name == "ZutaPosuda")
                {
                    GameObject gObject = GameObject.Find("ZutaPosuda");
                    Destroy(gObject);
                    GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(zutaPosudaSlika, "ZutaPosuda");
                }

                if (hit.transform.name == "ZelenaPosuda")
                {
                    GameObject gObject = GameObject.Find("ZelenaPosuda");
                    Destroy(gObject);
                    GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(zelenaPosudaSlika, "ZelenaPosuda");
                }
                
                //sipanje u veliki vrc
                if (System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "MaliVrc") != -1 &&
                    System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "MaliVrc") == InventorySkripta.indeksKliknutogDugmeta &&
                    hit.transform.name == "VelikiVrc")                
                {
                    //efekat nestajanja
                    StartCoroutine(animacijaNestajanjaVelikogVrca(GameObject.Find("VelikiVrc"), GameObject.Find("ZlatniKljuc")));
                }


                //glavna vrata treba otvoriti DORADITI!!!!!!!!!!!!!
                if (System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZlatniKljuc") != -1 &&
                    System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZlatniKljuc") == InventorySkripta.indeksKliknutogDugmeta &&
                    hit.transform.name == "dada")
                {

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
        if (System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "SvijecaPredmet") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "BoneUTamnici") != -1)
        {
            PomjeriVikinga.trebaTrcati = true;
        }
    }

    IEnumerator animacijaNestajanjaVelikogVrca(GameObject velikiVrc, GameObject zlatniKljuc)
    {
        audioSource.PlayOneShot(sipanjeTekucine);
        yield return new WaitForSeconds(5.0f);
        iTween.ScaleTo(velikiVrc, iTween.Hash("x", 0.05, "y", 0.05, "z", 0.05, "time", 4.0f));
        efekat.SetActive(true);
        efekat.GetComponent<ParticleSystem>().Play();

        iTween.ScaleTo(zlatniKljuc, iTween.Hash("x", 100, "y", 100, "z", 100, "time", 6.0f));
        yield return new WaitForSeconds(6.0f);

        Destroy(zlatniKljuc);
        GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(slikaZlatnogKljuca, "ZlatniKljuc");

    }
}

