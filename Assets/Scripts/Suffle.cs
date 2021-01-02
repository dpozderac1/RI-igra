using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Suffle : MonoBehaviour
{
    [SerializeField] private Transform[] transforms;
    [SerializeField] private Vector3[] positions;

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
                    StartCoroutine(ExampleCoroutine());
                }

            }
        }
            
    }

    IEnumerator ExampleCoroutine()
    {
        for(int i = 0; i < 10; i++)
        {
           
            int randomNumber = (Random.Range(0, positions.Length - 1));

            if (randomNumber == 0)
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
            }


        }
            
       
    }
}
