using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateParent : MonoBehaviour
{
    float x;
    float z;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("w");
        z = Input.GetAxis("d");

        if (Input.GetButtonDown("w"))
        {

            if (x == 1) gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            else if (x == -1) gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);


        }
        else if (Input.GetButtonDown("d"))
        {

            if (z == 1) gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (z == -1) gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

        }
    }
}
