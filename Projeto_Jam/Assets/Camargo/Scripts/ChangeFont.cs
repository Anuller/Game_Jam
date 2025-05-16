using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeFont : MonoBehaviour
{
    [SerializeField] TMP_Text characterName, dialogueText, lastLineText;
    [SerializeField] TMP_FontAsset estrelanca, narrador, outros;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (characterName.text == "ESTRELANÇA")
        {
            characterName.font = estrelanca;
            dialogueText.font = estrelanca;
            lastLineText.font = estrelanca;
        }
        else if (characterName.text == "Narrador")
        {
            characterName.font = narrador;
            dialogueText.font = narrador;
            lastLineText.font = narrador;
        }
        else
        {
            characterName.font = outros;
            dialogueText.font = outros;
            lastLineText.font = outros;
        }
    }
}
