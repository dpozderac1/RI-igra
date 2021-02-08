using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromijesajSolje : MonoBehaviour
{
    [SerializeField] private GameObject[] soljice;

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

                if (hit.transform.name == "First mug" || hit.transform.name == "Second mug" || hit.transform.name == "Third mug")
                {
                    StartCoroutine(Mijesaj());
                }

            }
        }

    }

    IEnumerator Mijesaj()
    {
        for (int i = 0; i < 10; i++)
        {
            int prviSlucajniBroj = (Random.Range(0, soljice.Length));
            int drugiSlucajniBroj = prviSlucajniBroj;
            while (drugiSlucajniBroj == prviSlucajniBroj)
            {
                drugiSlucajniBroj = (Random.Range(0, soljice.Length));
            }

            var pozicijaPrveSoljice = soljice[prviSlucajniBroj].transform.position;
            var pozicijaDrugeSoljice = soljice[drugiSlucajniBroj].transform.position;

            //podigni po y za 0.3f
            iTween.MoveTo(soljice[prviSlucajniBroj], iTween.Hash("y", pozicijaPrveSoljice.y + 0.3f,"time", 0.5f));
            iTween.MoveTo(soljice[drugiSlucajniBroj], iTween.Hash("y", pozicijaDrugeSoljice.y + 0.3f, "time", 0.5f));
            

            yield return new WaitForSeconds(0.5f);

            pozicijaPrveSoljice = soljice[prviSlucajniBroj].transform.position;
            pozicijaDrugeSoljice = soljice[drugiSlucajniBroj].transform.position;

            //zamijeni ih
            iTween.MoveTo(soljice[prviSlucajniBroj], pozicijaDrugeSoljice, 0.8f);
            iTween.MoveTo(soljice[drugiSlucajniBroj], pozicijaPrveSoljice, 0.8f);

            yield return new WaitForSeconds(0.8f);

            pozicijaPrveSoljice = soljice[prviSlucajniBroj].transform.position;
            pozicijaDrugeSoljice = soljice[drugiSlucajniBroj].transform.position;

            //spusti po y za 0.3f
            iTween.MoveTo(soljice[prviSlucajniBroj], iTween.Hash("y", pozicijaPrveSoljice.y - 0.3f, "time", 0.5f));
            iTween.MoveTo(soljice[drugiSlucajniBroj], iTween.Hash("y", pozicijaDrugeSoljice.y - 0.3f, "time", 0.5f));

            yield return new WaitForSeconds(0.5f);
            /*if (randomNumber == 0)
            {
                soljice[randomNumber].transform.position= new Vector3(pozicijaTrenutneSoljice.x, pozicijaTrenutneSoljice.y + 0.3f, pozicijaTrenutneSoljice.z);
                

                transforms[randomNumber + 1].position = new Vector3(transforms[randomNumber + 1].position.x, transforms[randomNumber + 1].position.y + 0.3f, transforms[randomNumber + 1].position.z);

                yield return new WaitForSeconds(1.0f);

                transforms[randomNumber].position = positions[randomNumber + 1];
                transforms[randomNumber + 1].position = positions[randomNumber];

                var tmp = positions[randomNumber + 1];
                positions[randomNumber + 1] = positions[randomNumber];
                positions[randomNumber] = tmp;

                yield return new WaitForSeconds(0.5f);
            }
            else if (randomNumber == 2)
            {
                transforms[randomNumber].position = new Vector3(transforms[randomNumber].position.x, transforms[randomNumber].position.y + 0.3f, transforms[randomNumber].position.z);
                transforms[randomNumber - 1].position = new Vector3(transforms[randomNumber - 1].position.x, transforms[randomNumber - 1].position.y + 0.3f, transforms[randomNumber - 1].position.z);

                yield return new WaitForSeconds(1.0f);

                transforms[randomNumber].position = positions[randomNumber - 1];
                transforms[randomNumber - 1].position = positions[randomNumber];

                var tmp1 = positions[randomNumber - 1];
                positions[randomNumber - 1] = positions[randomNumber];
                positions[randomNumber] = tmp1;

                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                transforms[randomNumber].position = new Vector3(transforms[randomNumber].position.x, transforms[randomNumber].position.y + 0.3f, transforms[randomNumber].position.z);
                transforms[randomNumber + 1].position = new Vector3(transforms[randomNumber + 1].position.x, transforms[randomNumber + 1].position.y + 0.3f, transforms[randomNumber + 1].position.z);

                yield return new WaitForSeconds(1.0f);

                transforms[randomNumber].position = positions[randomNumber + 1];
                transforms[randomNumber + 1].position = positions[randomNumber];

                var tmp = positions[randomNumber + 1];
                positions[randomNumber + 1] = positions[randomNumber];
                positions[randomNumber] = tmp;

                yield return new WaitForSeconds(0.5f);

                transforms[randomNumber].position = new Vector3(transforms[randomNumber].position.x, transforms[randomNumber].position.y + 0.3f, transforms[randomNumber].position.z);
                transforms[randomNumber - 1].position = new Vector3(transforms[randomNumber - 1].position.x, transforms[randomNumber - 1].position.y + 0.3f, transforms[randomNumber - 1].position.z);

                yield return new WaitForSeconds(1.0f);

                transforms[randomNumber].position = positions[randomNumber - 1];
                transforms[randomNumber - 1].position = positions[randomNumber];

                var tmp1 = positions[randomNumber - 1];
                positions[randomNumber - 1] = positions[randomNumber];
                positions[randomNumber] = tmp1;

                yield return new WaitForSeconds(0.5f);
            }*/


        }


    }
}
