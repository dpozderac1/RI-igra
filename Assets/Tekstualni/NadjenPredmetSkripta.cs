using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NadjenPredmetSkripta : MonoBehaviour
{

    public float trajanje;

    [Tooltip("Length of the fade")]
    [SerializeField]
    private float FadeTimer = 1f;

    [Tooltip("Delay until fades begins")]
    [SerializeField]
    private float FadeInDelay = 0f;

    GameObject prazan;


    /*public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;*/

    private Vector3 staraPozicijaSlike;
    // Start is called before the first frame update
    void Start()
    {
        prazan = GameObject.Find("PrazanObjekatNoviPredmet");
        prazan.GetComponent<CanvasGroup>().alpha = 0f;

        GameObject slikaZaTranslaciju = GameObject.Find("SlikaPredmeta");

        Color trenutnaBoja = slikaZaTranslaciju.GetComponent<Image>().color;
        trenutnaBoja.a = 0f;
        slikaZaTranslaciju.GetComponent<Image>().color = trenutnaBoja;

        staraPozicijaSlike = slikaZaTranslaciju.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.J))
        {
            prikaziObjekat(spr1);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            prikaziObjekat(spr2);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            prikaziObjekat(spr3);
        }*/

    }

    public void updateColor(float val)
    {
        prazan.GetComponent<CanvasGroup>().alpha = val;
    }

    //kad se pronadje da se prikaze koji je objekat pronadjen
    public void prikaziObjekat(Sprite spr,string naziv)
    {
        GameObject slikaZaTranslaciju = GameObject.Find("SlikaPredmeta");
        slikaZaTranslaciju.GetComponent<Image>().sprite = spr;

        int slobodnaPozicija = InventorySkripta.dajSljedeciNepopunjeni();


        StartCoroutine(transliraj(slobodnaPozicija,spr,naziv));

        //iTween.FadeTo(prazan, iTween.Hash("time", FadeTimer));

        //,"oncomplete","transliraj"
        //transliraj(slobodnaPozicija);
        //InventorySkripta.popuni(slobodnaPozicija, spr);
    }


    IEnumerator transliraj(int slobodnaPozicija, Sprite spr,string naziv)
    {
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0f, "to", 1f, "delay", FadeInDelay, "time", FadeTimer, "onupdate", "updateColor"));        
        yield return new WaitForSeconds(FadeTimer);

        GameObject slikaZaTranslaciju = GameObject.Find("SlikaPredmeta");
        //Vector3 staraPozicija = slikaZaTranslaciju.transform.position;
        Color trenutnaBoja = slikaZaTranslaciju.GetComponent<Image>().color;
        trenutnaBoja.a = 1f;
        slikaZaTranslaciju.GetComponent<Image>().color = trenutnaBoja;
        yield return new WaitForSeconds(1f);


        iTween.MoveTo(slikaZaTranslaciju, iTween.Hash("x", InventorySkripta.dajPozicijeDugmadi()[slobodnaPozicija].x, "y", InventorySkripta.dajPozicijeDugmadi()[slobodnaPozicija].y, "time", 2f));
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 1f, "to", 0f, "delay", FadeInDelay, "time", FadeTimer, "onupdate", "updateColor"));
        yield return new WaitForSeconds(2.5f);

        InventorySkripta.popuni(slobodnaPozicija, spr,naziv);

        slikaZaTranslaciju.transform.position = staraPozicijaSlike;
        trenutnaBoja = slikaZaTranslaciju.GetComponent<Image>().color;
        trenutnaBoja.a = 0f;
        slikaZaTranslaciju.GetComponent<Image>().color = trenutnaBoja;
    }

    /*void transliraj(int slobodnaPozicija)
    {
        Debug.Log("Pozvano");
        GameObject slikaZaTranslaciju = GameObject.Find("SlikaPredmeta");

        Color trenutnaBoja = slikaZaTranslaciju.GetComponent<Image>().color;
        trenutnaBoja.a = 1f;
        slikaZaTranslaciju.GetComponent<Image>().color = trenutnaBoja;

        iTween.MoveBy(slikaZaTranslaciju, iTween.Hash("x", InventorySkripta.dajPozicijeDugmadi()[slobodnaPozicija].x - slikaZaTranslaciju.transform.position.x, "y", InventorySkripta.dajPozicijeDugmadi()[slobodnaPozicija].y - slikaZaTranslaciju.transform.position.y, "time", 0.5f));     
    }*/

    

}

