using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class textAnimation : MonoBehaviour
{
    public string frase;
    public TextMeshProUGUI texto;
    public float tempoIn, tempoMax;
    //public GameObject back;

    void Start()
    {
        StartCoroutine(AnimText());
    }

    IEnumerator AnimText()
    {
        /*yield return new WaitForSeconds(3f);

        Destroy(back);*/

        //yield return new WaitForSeconds(6f);

        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(tempoIn);
        }

        /*yield return new WaitForSeconds(tempoMax);

        Destroy(texto);*/
    }

}
