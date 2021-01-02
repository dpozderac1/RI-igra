using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] private Vector3 openPosition, closedPosition;
    [SerializeField] private float animationTime;

    [SerializeField] private bool isOpen = false;
    private Hashtable iTweenArgs;
    // Start is called before the first frame update
    void Start()
    {
        iTweenArgs = iTween.Hash();
        iTweenArgs.Add("position", closedPosition);
        iTweenArgs.Add("time", animationTime);
        iTweenArgs.Add("islocal", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isOpen)
            {
                iTweenArgs["position"] = closedPosition;
            }
            else
            {
                iTweenArgs["position"] = openPosition;
            }

            isOpen = !isOpen;

            iTween.MoveTo(gameObject, iTweenArgs);

        }
    }
    /*[SerializeField] private Vector3 openPosition, closedPosition, openRotate, closedRotate;

    [SerializeField] private float animationTime;

    [SerializeField] private bool isOpen = false;
    private bool _isInsideTrigger = false;

    private Hashtable iTweenArgs, iTweenArgsRotate;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
            {
                iTweenArgs["position"] = closedPosition;
                iTweenArgsRotate["rotation"] = closedRotate;
            }
            else
            {
                iTweenArgs["position"] = openPosition;
                iTweenArgsRotate["rotation"] = openRotate;
            }

            isOpen = !isOpen;

            iTween.MoveTo(gameObject, iTweenArgs);
            iTween.RotateTo(gameObject, iTweenArgsRotate);

        }

    }

    void OnTriggerEnter(Collider other)
    {
        _isInsideTrigger = true;

    }

    void OnTriggerExit(Collider other)
    {
        _isInsideTrigger = false;
    }*/
}
