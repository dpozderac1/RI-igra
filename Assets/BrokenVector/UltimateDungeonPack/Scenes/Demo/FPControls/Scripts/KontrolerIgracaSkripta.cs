﻿/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolerIgracaSkripta : MonoBehaviour
{
    public float speed = 10.0f;
    private float translation;
    private float straffe;

    public static bool zakocenIgrac = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        if (!zakocenIgrac)
        {
            translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            transform.Translate(straffe, 0, translation);
        }
        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public static void ukociOtkociIgraca()
    {
        zakocenIgrac = !zakocenIgrac;
    }
}
