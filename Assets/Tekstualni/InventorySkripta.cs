using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shapes2D;

public class InventorySkripta : MonoBehaviour
{
    static Button[] dugmadi;

    static bool[] popunjeno;

    static Vector3[] pozicijeDugmadi;

    public static int indeksKliknutogDugmeta;

    private Shape drugaSkripta;

    public static string[] naziviNadjenihPredmeta;

    // Start is called before the first frame update
    void Start()
    {
        popunjeno = new bool[6];
        dugmadi = new Button[6];
        pozicijeDugmadi = new Vector3[6];
        naziviNadjenihPredmeta = new string[6];
        for (int i = 0; i < dugmadi.Length; i++)
        {
            popunjeno[i] = false;
            dugmadi[i] = GameObject.Find("InventoryButton" + (i + 1).ToString()).GetComponent<Button>();
            pozicijeDugmadi[i] = dugmadi[i].transform.position;
        }
        indeksKliknutogDugmeta = -1;                
    }

    public static void popuni(int indeks, Sprite spr,string naziv)
    {
        popunjeno[indeks] = true;
        naziviNadjenihPredmeta[indeks] = naziv;

        //prikazi sliku koja se nalazi u dugmetu
        Image slikaUDugmetu = dugmadi[indeks].GetComponentInChildren<Image>();
        Transform dijete = slikaUDugmetu.gameObject.transform;
        slikaUDugmetu = dijete.Find("Image").GetComponent<Image>();
        slikaUDugmetu.sprite = spr;
        Color trenutnaBoja = slikaUDugmetu.color;

        trenutnaBoja.a = 1f;
        slikaUDugmetu.color = trenutnaBoja;        
    }

    public static int dajSljedeciNepopunjeni()
    {
        int sljedeci = -1;
        for (int i = 0; i < popunjeno.Length; i++)
        {
            if (popunjeno[i] == false)
            {
                sljedeci = i;
                break;
            }
        }
        return sljedeci;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3[] dajPozicijeDugmadi()
    {
        return pozicijeDugmadi;
    }

    public void kliknutoDugme(int indeks)
    {
        if (popunjeno[indeks])
        {
            if (indeks == indeksKliknutogDugmeta)
            {
                dugmadi[indeks].GetComponent<Image>().color = new Color(255, 255, 255);
                indeksKliknutogDugmeta = -1;
            }
            else
            {
                dugmadi[indeks].GetComponent<Image>().color = new Color(255,220, 0);                
                for (int i = 0; i < dugmadi.Length; i++)
                {
                    if (i != indeks)
                    {
                        dugmadi[i].GetComponent<Image>().color = new Color(255, 255, 255);
                    }
                }
                indeksKliknutogDugmeta = indeks;
            }
        }
    }
}

