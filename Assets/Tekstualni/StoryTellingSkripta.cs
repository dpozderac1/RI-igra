using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTellingSkripta : MonoBehaviour
{
    //public Sprite[] novaSlika;

    public void Start()
    {
        Button dugme = GameObject.Find("TestButton").GetComponent<Button>();
        dugme.onClick.Invoke();
        AudioSource izvor = GameObject.Find("PrazanObjekat").GetComponent<AudioSource>();
        izvor.volume = OptionsSkripta.glasnocaZvuka;
        //FindObjectOfType<DijalogTrigger>().TriggerDialogue();
    }

    /*public void promijeniSliku()
    {
        GameObject slika = GameObject.Find("Background");
        for (int i = 0; i < novaSlika.Length; i++)
        {
            slika.GetComponent<Image>().sprite = novaSlika[i];
        }
    }*/
}
