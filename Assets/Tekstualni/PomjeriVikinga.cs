using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PomjeriVikinga : MonoBehaviour
{
    GameObject viking;

    public RuntimeAnimatorController hodaAnimator;
    public RuntimeAnimatorController trciAnimator;
    public RuntimeAnimatorController idleAnimator;
    public static bool trebaTrcati = false;
    bool azurirajHodanje = true;

    // Start is called before the first frame update
    void Start()
    {
        viking = GameObject.Find("Srin_1");
    }

    // Update is called once per frame
    void Update()
    {
        if (!trebaTrcati && azurirajHodanje)
        {
            hoda();
        }
        else if (trebaTrcati && viking.transform.position.x < -18.5)
        {
            hoda();
        }
        else if (trebaTrcati && Math.Round(viking.transform.position.x) >= -18.5)
        {
            Debug.Log("Trci");
            trci();
        }
    }


    void trci()
    {        
        if (viking.transform.position.z < 9)
        {
            viking.GetComponent<Animator>().runtimeAnimatorController = hodaAnimator;
            viking.transform.position = new Vector3(viking.transform.position.x, viking.transform.position.y, viking.transform.position.z + 0.01f);
        }
        else if (viking.transform.position.z >= 9 && viking.transform.eulerAngles.y < 90)
        {

            StartCoroutine(okreniSeLijevo());
        }
        else if (viking.transform.position.z >= 9 && viking.transform.eulerAngles.y > 90)
        {
            Debug.Log("Trebao bi trcati");
            viking.GetComponent<Animator>().runtimeAnimatorController = trciAnimator;

            viking.transform.position = new Vector3(viking.transform.position.x + 0.05f, viking.transform.position.y, viking.transform.position.z);
            if (viking.transform.position.x > -6)
            {
                Destroy(viking);
            }
        }
    }

    void hoda()
    {
        if (viking.GetComponent<Animator>().runtimeAnimatorController != hodaAnimator)
        {
            viking.GetComponent<Animator>().runtimeAnimatorController = hodaAnimator;
        }

        if (viking.transform.eulerAngles.y > 180)
        {            
            viking.transform.position = new Vector3(viking.transform.position.x - 0.01f, viking.transform.position.y, viking.transform.position.z);
        }
        else
        {
            viking.transform.position = new Vector3(viking.transform.position.x + 0.01f, viking.transform.position.y, viking.transform.position.z);
        }


        //treba se okrenuti i vratiti
        if (viking.transform.position.x > -18.5)
        {
            StartCoroutine(okreniSePremaKraju());
        }
        else if (viking.transform.position.x < -28)
        {
            StartCoroutine(okreniSePremaPocetku());
        }
    }

    IEnumerator okreniSePremaKraju()
    {
        viking.GetComponent<Animator>().runtimeAnimatorController = idleAnimator;
        iTween.RotateTo(viking, new Vector3(viking.transform.rotation.x, 0, viking.transform.rotation.z), 4f);
        azurirajHodanje = false;
        yield return new WaitForSeconds(4f);
        if (!trebaTrcati)
        {
            iTween.RotateTo(viking, new Vector3(viking.transform.rotation.x, 270, viking.transform.rotation.z), 4f);
            yield return new WaitForSeconds(4f);
        }
        azurirajHodanje = true;
    }

    IEnumerator okreniSePremaPocetku()
    {
        viking.GetComponent<Animator>().runtimeAnimatorController = idleAnimator;
        iTween.RotateTo(viking, new Vector3(viking.transform.rotation.x, 90, viking.transform.rotation.z), 8f);
        azurirajHodanje = false;
        yield return new WaitForSeconds(8f);
        azurirajHodanje = true;
    }


    IEnumerator okreniSeLijevo()
    {
        Debug.Log("Okreni se lijevo");
        viking.GetComponent<Animator>().runtimeAnimatorController = idleAnimator;
        iTween.RotateTo(viking, new Vector3(viking.transform.rotation.x, 91, viking.transform.rotation.z), 4f);
        yield return new WaitForSeconds(4f);

    }
}