using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KliknutPredmetNivo3 : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition, closedPosition, openRotate, closedRotate;

    private Hashtable iTweenArgs, iTweenArgsRotate;

    public AudioSource audio;

    public AudioClip kraj;

    private GameObject panel;

    private GameObject panelSaPredmetima;

    public Sprite cekicSlika;

    [Header("Whole Create")]
    public MeshRenderer wholeCrate;
    public BoxCollider boxCollider;
    [Header("Fractured Create")]
    public GameObject fracturedCrate;
    [Header("Audio")]
    public AudioSource crashAudioClip;


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

        panel = GameObject.Find("PanelKraj");
        panel.gameObject.SetActive(false);
        panelSaPredmetima = GameObject.Find("Panel");


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
                if (hit.transform.name == "Koliba vrata" && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZlatniKljuc") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "ZlatniKljuc") == InventorySkripta.indeksKliknutogDugmeta)
                {
                    GameObject gObject = GameObject.Find(hit.transform.name);
                    iTween.MoveTo(gObject, iTweenArgs);
                    iTween.RotateTo(gObject, iTweenArgsRotate);
                    StartCoroutine(Kraj());
                }
                
                if (hit.transform.name == "Cekic")
                {
                    GameObject.Find("NadjenPredmetDugme").GetComponent<NadjenPredmetSkripta>().prikaziObjekat(cekicSlika, "Cekic");
                    Destroy(GameObject.Find("Cekic"));
                }
                if (hit.transform.name == "KutijaFlase" && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "Cekic") != -1 && System.Array.IndexOf(InventorySkripta.naziviNadjenihPredmeta, "Cekic") == InventorySkripta.indeksKliknutogDugmeta)
                {
                    wholeCrate.enabled = false;
                    boxCollider.enabled = false;
                    fracturedCrate.SetActive(true);
                    crashAudioClip.Play();
                }

            }
        }
    }

    IEnumerator Kraj()
    {
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = kraj;
        audio.Play();

        panelSaPredmetima.gameObject.SetActive(false);
        panel.gameObject.SetActive(true);
        Image img = panel.GetComponent<Image>();
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
    }
}
