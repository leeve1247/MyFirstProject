using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrint : MonoBehaviour
{
    float sec = 3f;
    float time = 0f;

    Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();

        myButton.interactable = false;
    } 




    public void PrintConsole()
    {
        Debug.Log("나는 버튼이다.");
    }


    void Update()
    {

        time += Time.deltaTime;

        if (time > sec)
        {
            myButton.interactable = true;
        }


    }


}
