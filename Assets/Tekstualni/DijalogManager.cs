using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DijalogManager : MonoBehaviour
{
    private Queue<string> recenice;
    private int prikazaneRecenice=0;

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public int ucitajScenu;

    //public Sprite novaSlika;


    /*[Tooltip("Reference to a UI image for fading in")]
    [SerializeField]
    private UnityEngine.UI.Image FadeImage;

    [Tooltip("Length of the fade")]
    [SerializeField]
    private float FadeTimer = 2f;

    [Tooltip("Delay until fade begins")]
    [SerializeField]
    private float FadeInDelay = 1f;

    [Tooltip("Color to fade to")]
    [SerializeField]
    private Color EndColor = Color.white;

    [Tooltip("Color to fade from")]
    [SerializeField]
    private Color StartColor = Color.clear;*/

    // Start is called before the first frame update
    void Start()
    {
        recenice = new Queue<string>();
        //FadeImage = GameObject.Find("BackgroundStoryTelling").GetComponent<Image>();
    }

    public void StartDialogue(Dijalog dijalog)
    {

        animator.SetBool("isOpen", true);

        nameText.text = dijalog.name;

        recenice.Clear();
        foreach(string recenica in dijalog.recenice)
        {
            recenice.Enqueue(recenica);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (recenice.Count == 0)
        {
            EndDialogue();
            return;
        }

        string recenica = recenice.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(recenica));
    }

    IEnumerator TypeSentence(string recenica)
    {
        GameObject slika = GameObject.Find("BackgroundStoryTelling");
        if (slika != null && prikazaneRecenice>0)
        {            
            iTween.MoveBy(slika, iTween.Hash("y", 50, "easeType", "linear"));
        }
        prikazaneRecenice++;
        dialogueText.text = "";
        foreach (char slovo in recenica.ToCharArray())
        {
            dialogueText.text += slovo;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End Dialogue");

        if (ucitajScenu >= 0)
        {
            SceneManager.LoadScene(3);
        }
    }

    

    /*public void updateColor(float val)
    {
        FadeImage.color = ((1f - val) * StartColor) + (val * EndColor);
    }*/

    /*private void Fade()
    {        
        iTween.ValueTo(this.gameObject, iTween.Hash("from", 0f, "to", 3f, "delay", FadeInDelay, "time", FadeTimer, "onupdate", "updateColor"));
    }*/
}
