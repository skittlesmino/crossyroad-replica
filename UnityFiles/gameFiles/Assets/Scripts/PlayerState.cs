using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isAlive = true;
    public GameObject text;
    bool hasPressed = false;
    public void Death()
    {
        if (isAlive = true)
        {
            isAlive = false;
            text.SetActive(true);
            GlobalVariables.outOfBounds = false;
            StartCoroutine("WaitForAction");
        }
    }

    IEnumerator WaitForAction()
    {
        
            while(hasPressed == false) {
            if (Input.GetKeyDown("f")) {
                FindObjectOfType<Manager>().EndGame();
                hasPressed = true;
            }
            yield return null;
            }
    }

    // Update is called once per frame
}
