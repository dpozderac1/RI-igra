using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KockaPrepreka : MonoBehaviour
{
    public GameObject kocka1;
    public GameObject kocka2;
    public GameObject kocka3;

    bool kreciSe1 = true;
    bool kreciSe2 = true;
    bool kreciSe3 = true;

    // Start is called before the first frame update
    void Start()
    {
        //kocka1.transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (kreciSe1)
        {
            StartCoroutine(pomjerajVani(kocka1, 1, 4.0f, 0.0f));
        }
        if (kreciSe2)
        {
            StartCoroutine(pomjerajVani(kocka2, 2, 6.0f, 1.0f));
        }
        if (kreciSe3)
        {
            StartCoroutine(pomjerajVani(kocka3, 3, 2.0f, 2.0f));
        }
    }

    IEnumerator pomjerajVani(GameObject trenutnaKocka, int redoslijed, float vrijeme, float vrijemeCekanja)
    {
        if (redoslijed == 1)
        {
            kreciSe1 = false;
        }
        else if (redoslijed == 2)
        {
            kreciSe2 = false;
        }
        else
        {
            kreciSe3 = false;
        }

        yield return new WaitForSeconds(vrijemeCekanja);
        iTween.MoveTo(trenutnaKocka, new Vector3(trenutnaKocka.transform.position.x - 2.0f, trenutnaKocka.transform.position.y, trenutnaKocka.transform.position.z), vrijeme);
        
        yield return new WaitForSeconds(vrijeme);
        iTween.MoveTo(trenutnaKocka, new Vector3(trenutnaKocka.transform.position.x + 2.0f, trenutnaKocka.transform.position.y, trenutnaKocka.transform.position.z), vrijeme);
        
        yield return new WaitForSeconds(vrijeme);

        if (redoslijed == 1)
        {
            kreciSe1 = true;
        }
        else if (redoslijed == 2)
        {
            kreciSe2 = true;
        }
        else
        {
            kreciSe3 = true;
        }
    }
}
