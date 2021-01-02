using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSkripta : MonoBehaviour
{
    public static bool ukljucenZvuk = true;
    public static float glasnocaZvuka = 1.0f;

    public void promijeniUkljucenZvuk()
    {        
        ukljucenZvuk = !ukljucenZvuk;
        Debug.Log("Ukljucen zvuk: " + ukljucenZvuk.ToString());
    }

    public void promijeniGlasnocu(System.Single vrijednost)
    {
        Debug.Log("Vrijednost je: "+vrijednost.ToString());
        glasnocaZvuka = vrijednost;
    }
}
