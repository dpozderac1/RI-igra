using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KliknutPredmet : MonoBehaviour
{
    public Sprite slikaBone;
    public Sprite slikaKljuca;
    public Sprite zutaPosudaSlika;
    public Sprite zelenaPosudaSlika;
    public Sprite maliVrcSlika;
    public Sprite slikaZlatnogKljuca;
    public Sprite nozSlika;
    public Sprite kantaSlika;
    public Sprite kantaSaVodomSlika;

    private static bool otvorenaVrata = false;

    bool otvoriVrataPoredPrekidaca = false;
    int[] prekidaciPoredVrata = { 0, 0, 0 };

    public GameObject svijecaNaStolu;

    bool dodanaZuta = false;
    bool dodanaZelena = false;

    public AudioSource audioSource;
    public AudioClip sipanjeTekucine;

    public GameObject efekat;

    //public static bool zavrsenaPuzzla=false;
    bool otvorenaVrataUSobi = false;

    public GameObject unosTeksta;
    GameObject pritisnuoTekst;
    int[] pravaKombinacijaVrceva = { 8507, 1710, 1512, 7251, 5021 };
    bool pomjerenSto = false;

    public GameObject kantaObjekat;
    public GameObject drugaKantaObjekat;
    public GameObject sipanjeVodeParticle;

    bool otvorioBure = false;

    private int nivo = 1; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera kamera = null;
            if(GameObject.Find("Camera"))
            {
                kamera = GameObject.Find("Camera").GetComponent<Camera>();
            }
            /*else if (GameObject.Find("Camera_high"))
            {
                Debug.Log("Klik");
                kamera = GameObject.Find("Camera_high").GetComponent<Camera>();
                nivo = 3;
            }*/

            Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                /*if (nivo == 3 && hit.transform.name == "Koliba vrata" && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZlatniKljuc") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZlatniKljuc") == InventorySkripta.indeksKliknutogDugmeta)
                {
                    Debug.Log("Klik1");
                    GameObject gObject = GameObject.Find(hit.transform.name);
                    iTween.RotateBy(gObject, iTween.Hash("z", 0.35f, "time", 4f));
                }*/

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


                if(hit.transform.name== "KnjigaZaCrtanje")
                {
                    SacuvajVarijableZaPuzzleSkripta.pozicijaIgraca = GameObject.Find("Capsule").transform.position;
                    SacuvajVarijableZaPuzzleSkripta.rotacijaIgraca = GameObject.Find("Capsule").transform.rotation;
                    GameObject.Find("UcitajSljedecuScenuDugme").GetComponent<Button>().onClick.Invoke();
                }

                if (hit.transform.name == "NozUSobi" && SacuvajVarijableZaPuzzleSkripta.zavrsenaPuzzla)
                {
                    GameObject gObject = GameObject.Find("NozUSobi");
                    Destroy(gObject);
                    GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(nozSlika, "NozUSobi");
                }

                if (hit.transform.name == "MeadBottleSkrozDesno")
                {
                    pritisnuoTekst = GameObject.Find("SkrozDesnoTekst");
                    unosTeksta.SetActive(true);
                    unosTeksta.GetComponent<InputField>().Select();
                }

                if (hit.transform.name == "HempBeckerDesno")
                {
                    pritisnuoTekst = GameObject.Find("DesnoTekst");
                    unosTeksta.SetActive(true);
                    unosTeksta.GetComponent<InputField>().Select();
                }

                if (hit.transform.name == "MugUSredini")
                {
                    pritisnuoTekst = GameObject.Find("SredinaTekst");
                    unosTeksta.SetActive(true);
                    unosTeksta.GetComponent<InputField>().Select();
                }

                if (hit.transform.name == "EmptyBeckerLijevo")
                {
                    pritisnuoTekst = GameObject.Find("LijevoTekst");
                    unosTeksta.SetActive(true);
                    unosTeksta.GetComponent<InputField>().Select();
                }

                if (hit.transform.name == "HempBeckerSkrozLijevo")
                {
                    pritisnuoTekst = GameObject.Find("SkrozLijevoTekst");
                    unosTeksta.SetActive(true);
                    unosTeksta.GetComponent<InputField>().Select();
                }

                if(kantaObjekat.activeInHierarchy && hit.transform.name == "Kanta")
                {
                    kantaObjekat.SetActive(false);
                    GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(kantaSlika, "Kanta");
                }

                if(System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "NozUSobi") != -1 &&
                    System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "NozUSobi") == InventorySkripta.indeksKliknutogDugmeta &&
                    hit.transform.name == "VelikoBure")
                {
                    otvorioBure = true;
                }

                if (otvorioBure && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "Kanta") != -1 &&
                    System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "Kanta") == InventorySkripta.indeksKliknutogDugmeta &&
                    hit.transform.name == "VelikoBure")
                {
                    //600540.8, 59189, 1555420

                    //treba slika napunjene kante vodom

                    //animacija sipanja vode
                    drugaKantaObjekat.SetActive(true);
                    sipanjeVodeParticle.SetActive(true);

                    InventorySkripta.indeksKliknutogDugmeta = -1;
                    int indeksKante = System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "Kanta");
                    InventorySkripta.popunjeno[indeksKante] = false;
                    Image slikaUDugmetu = InventorySkripta.dugmadi[indeksKante].GetComponentInChildren<Image>();
                    Transform dijete = slikaUDugmetu.gameObject.transform;
                    slikaUDugmetu = dijete.Find("Image").GetComponent<Image>();
                    slikaUDugmetu.sprite = null;
                    InventorySkripta.naziviNadjenihPredmeta[indeksKante] = "";

                    StartCoroutine(sipanjeVodeUKantu());                    
                }

                if(System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "KantaSaVodom") != -1 &&
                    System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "KantaSaVodom") == InventorySkripta.indeksKliknutogDugmeta && hit.transform.name== "fx_fire_g")
                {
                    Debug.Log("Ugasi vatru");
                    GameObject obj = GameObject.Find("fx_fire_g");
                    Destroy(obj);
                }

                Debug.Log("Kliknuto je: " + hit.transform.name);
            }
        }

        if (GameObject.Find("SkrozLijevoTekst").GetComponent<TMP_Text>().text == "8507" &&
                    GameObject.Find("LijevoTekst").GetComponent<TMP_Text>().text == "1710" &&
                    GameObject.Find("SredinaTekst").GetComponent<TMP_Text>().text == "1512" &&
                    GameObject.Find("DesnoTekst").GetComponent<TMP_Text>().text == "7251" &&
                    GameObject.Find("SkrozDesnoTekst").GetComponent<TMP_Text>().text == "5021" &&
                    !pomjerenSto)
        {            
            iTween.MoveTo(GameObject.Find("StolicaZaIzmicanje"), new Vector3(0.201f, 1.0f, -25.099f), 4.0f);

            iTween.MoveTo(GameObject.Find("StoZaMicanje"), new Vector3(4.173722f, 1.0f, -22.80202f), 4.0f);
            iTween.MoveTo(GameObject.Find("TanjirZaMicanje"), new Vector3(3.3f, 1.827515f, -22.99139f), 4.0f);
            iTween.MoveTo(GameObject.Find("TanjirZaMicanje1"), new Vector3(4.8f, 1.827515f, -22.93712f), 4.0f);
            iTween.MoveTo(GameObject.Find("ViljuskaZaMicanje"), new Vector3(3.0f, 1.8492f, -23.034f), 4.0f);
            iTween.MoveTo(GameObject.Find("ViljuskaZaMicanje1"), new Vector3(4.486971f, 1.8492f, -22.98568f), 4.0f);
            iTween.MoveTo(GameObject.Find("NozZaMicanje"), new Vector3(3.556252f, 1.844f, -23.04841f), 4.0f);
            iTween.MoveTo(GameObject.Find("NozZaMicanje1"), new Vector3(5.183217f, 1.844f, -23.03518f), 4.0f);            
            iTween.MoveTo(GameObject.Find("DesnoTekst"), new Vector3(3.6293f, 1.8357f, -22.704f), 4.0f);
            iTween.MoveTo(GameObject.Find("SkrozDesnoTekst"), new Vector3(5.116f, 1.828f, -22.626f), 4.0f);
            iTween.MoveTo(GameObject.Find("MeadBottleSkrozDesno"), new Vector3(5.068f, 1.844882f, -22.534f), 4.0f);
            iTween.MoveTo(GameObject.Find("HempBeckerDesno"), new Vector3(3.577f, 1.841204f, -22.55f), 4.0f);

            kantaObjekat.SetActive(true);
            pomjerenSto = true;
        }        

        if (!otvorenaVrataUSobi && SacuvajVarijableZaPuzzleSkripta.zavrsenaPuzzla)
        {
            Debug.Log("Otvori vrata");
            GameObject gObject = GameObject.Find("Vrata Otvara Knjiga");
            iTween.RotateBy(gObject, iTween.Hash("z", -0.30f, "time", 4f));
            gObject = GameObject.Find("PovrsinaZaUgraviranuSlikuKnjige");
            Destroy(gObject);
            otvorenaVrataUSobi = true;
        }

        if (SacuvajVarijableZaPuzzleSkripta.vratioSeIzScene)
        {
            GameObject.Find("Capsule").transform.position = SacuvajVarijableZaPuzzleSkripta.pozicijaIgraca;
            GameObject.Find("Capsule").transform.rotation = SacuvajVarijableZaPuzzleSkripta.rotacijaIgraca;
            SacuvajVarijableZaPuzzleSkripta.vratioSeIzScene = false;
            Debug.Log("Desilo se");
        }

        

        if (Input.GetKeyDown(KeyCode.Return) && unosTeksta.activeInHierarchy)
        {
            pritisnuoTekst.GetComponent<TMP_Text>().text = unosTeksta.GetComponent<InputField>().text;
            unosTeksta.GetComponent<InputField>().text = "";
            unosTeksta.SetActive(false);
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

    IEnumerator sipanjeVodeUKantu()
    {
        //dodati zvuk
        yield return new WaitForSeconds(4.0f);
        sipanjeVodeParticle.SetActive(false);
        drugaKantaObjekat.SetActive(false);
        GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(kantaSaVodomSlika, "KantaSaVodom");
    }
}

