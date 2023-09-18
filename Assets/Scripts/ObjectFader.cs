using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    public float fadeSpeed, fadeAmount;
    float myOriginalOpacity;

    public bool isFaded = false;

    Material[] myMaterial;

    // Start is called before the first frame update
    void Start()
    {
        // save original opacity value 
        if (TryGetComponent<Renderer>(out Renderer renderer))
        {
            myMaterial = renderer.materials;

            foreach (Material mat in myMaterial)
            {
                myOriginalOpacity = mat.color.a;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isFaded)
        {
            FadeMode();
        }

        else
        {
            ResetFade();
        }

    }


    void FadeMode()
    {
        foreach (Material mat in myMaterial)
        {
            Color curColor = mat.color;
            Color smoothColor = new Color(curColor.r, curColor.g, curColor.b,
            Mathf.Lerp(curColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
            mat.color = smoothColor;
        }
    }

    void ResetFade()
    {
        foreach (Material mat in myMaterial)
        {
            Color curColor = mat.color;
            Color smoothColor = new Color(curColor.r, curColor.g, curColor.b,
            Mathf.Lerp(curColor.a, myOriginalOpacity, fadeSpeed * Time.deltaTime));
            mat.color = smoothColor;
        }
    }
}
