using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DijalogTrigger : MonoBehaviour
{
    public Dijalog dijalog;

    public void TriggerDialogue()
    {        
        FindObjectOfType<DijalogManager>().StartDialogue(dijalog);

    }
}
