using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dropValuar : MonoBehaviour
{
    public int correctAnswer;
    //public GameObject object1, object2, object3;
    public TMP_Dropdown dropdown;
    bool currectAnswer;

    public void DropDowm(int index)
    {
        switch (index)
        {
            case 1:
                /*object1.SetActive(true);
                object2.SetActive(false);
                object3.SetActive(false);*/
                dropdown.alphaFadeSpeed = 0;
                break;

            case 2:
                /*object1.SetActive(false);
                object2.SetActive(true);
                object3.SetActive(false);*/
                dropdown.alphaFadeSpeed = 0;
                break;
            case 3:
                /*object1.SetActive(false);
                object2.SetActive(false);
                object3.SetActive(true);*/
                dropdown.alphaFadeSpeed = 0;
                break;
        }
    }


}
