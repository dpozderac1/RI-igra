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

    private static bool otvoreno=false;

    public Sprite slikaKljucaSprite;

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
            Camera kamera = GameObject.Find("Camera").GetComponent<Camera>();
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


        if (!otvoreno && counter[0] == tacnaKombinacija[0] && counter[1] == tacnaKombinacija[1] && counter[2] == tacnaKombinacija[2] && counter[3] == tacnaKombinacija[3])
        {

            iTween.MoveTo(gameObject, iTweenArgs);
            iTween.RotateTo(gameObject, iTweenArgsRotate);

            otvoreno = !otvoreno;
            StartCoroutine(PrikaziKljucKorutina());            
        }

    }

    IEnumerator PrikaziKljucKorutina()
    {
        GameObject kljuc = GameObject.Find("KljucUTamnici");
        Vector3 pozicija = kljuc.transform.position;
        pozicija.y += 0.5f;
        iTween.MoveTo(kljuc, iTween.Hash("position", pozicija, "time", 2f));
        yield return new WaitForSeconds(2f);
        Destroy(kljuc);
        GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(slikaKljucaSprite,"KljucUTamnici");
    }

    private int Add (ref int counter)
    {
        counter++;
        counter %= 10;
        return counter;
    }
}
