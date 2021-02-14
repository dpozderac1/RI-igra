using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition, closedPosition, openRotate, closedRotate;

    [SerializeField] private float animationTime;

    [SerializeField] private bool isOpen = false;

    [SerializeField] private GameObject firstNumber, secondNumber, thirdNumber, fourthNumber;

    private Hashtable iTweenArgs, iTweenArgsRotate;

    private int[] counter = { 0, 0, 0, 0 };

    private int[] tacnaKombinacija = { 7, 4, 1, 5 };

    private int[] tacnaKombinacijaNivo3 = { 2, 1, 4, 8 };

    private static bool otvoreno=false;

    public Sprite slikaSvijeceSprite;

    private int nivo = 1;

    // Start is called before the first frame update
    void Start()
    {
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", openPosition);
        iTweenArgs.Add("time", animationTime);
        iTweenArgs.Add("islocal", true);

        iTweenArgsRotate = iTween.Hash();
        iTweenArgsRotate.Add("rotation", openRotate);
        iTweenArgsRotate.Add("time", animationTime);
        iTweenArgsRotate.Add("islocal", true);

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Camera kamera = null;
            if(GameObject.Find("Camera"))
            {
                kamera = GameObject.Find("Camera").GetComponent<Camera>();
            }
            else if (GameObject.Find("Camera_high"))
            {
                kamera = GameObject.Find("Camera_high").GetComponent<Camera>();
                nivo = 3;
            }

          
            Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "First number")
                {
                    firstNumber.GetComponent<TextMesh>().text = Add(ref counter[0]).ToString();
                }
                if (hit.transform.name == "Second number")
                {
                    secondNumber.GetComponent<TextMesh>().text = Add(ref counter[1]).ToString();
                }
                if (hit.transform.name == "Third number")
                {
                    thirdNumber.GetComponent<TextMesh>().text = Add(ref counter[2]).ToString();
                }
                if (hit.transform.name == "Fourth number")
                {
                    fourthNumber.GetComponent<TextMesh>().text = Add(ref counter[3]).ToString();
                }

            }

           
        }

        if (nivo == 1 && !otvoreno && counter[0] == tacnaKombinacija[0] && counter[1] == tacnaKombinacija[1] && counter[2] == tacnaKombinacija[2] && counter[3] == tacnaKombinacija[3])
        {

            iTween.MoveTo(gameObject, iTweenArgs);
            iTween.RotateTo(gameObject, iTweenArgsRotate);

            otvoreno = !otvoreno;
            StartCoroutine(PrikaziKljucKorutina());            
        }
        else if (nivo == 3 && !otvoreno && counter[0] == tacnaKombinacijaNivo3[0] && counter[1] == tacnaKombinacijaNivo3[1] && counter[2] == tacnaKombinacijaNivo3[2] && counter[3] == tacnaKombinacijaNivo3[3])
        {

            iTween.MoveTo(gameObject, iTweenArgs);
            iTween.RotateTo(gameObject, iTweenArgsRotate);

            otvoreno = !otvoreno;
            StartCoroutine(PrikaziKljucKorutina());
        }

    }

    IEnumerator PrikaziKljucKorutina()
    {

        GameObject svijeca = null;
        if(nivo == 1)
        {
            svijeca = GameObject.Find("SvijecaPredmet");
        }
        else if (nivo == 3)
        {
            svijeca = GameObject.Find("ZlatniKljuc");
        }
        Vector3 pozicija = svijeca.transform.position;
        pozicija.y += 0.5f;
        iTween.MoveTo(svijeca, iTween.Hash("position", pozicija, "time", 2f));
        yield return new WaitForSeconds(2f);
        Destroy(svijeca);
        if(nivo == 1)
        {
            GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(slikaSvijeceSprite, "SvijecaPredmet");
        }
        else if(nivo == 3)
        {
            GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(slikaSvijeceSprite, "ZlatniKljuc");
        }
    }

    private int Add (ref int counter)
    {
        counter++;
        counter %= 10;
        return counter;
    }
}
