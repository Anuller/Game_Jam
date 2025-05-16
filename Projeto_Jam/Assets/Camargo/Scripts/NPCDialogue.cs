using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPCDialogue : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    public string conversationStartNode;
    [SerializeField] private bool isCurrentConversation, interactable;
    [SerializeField] bool isFirstTime = true;
    [SerializeField] float distancia, distanciaMax;
 
    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, gameObject.transform.position);
        if (name == "Professor" && GameController.Instance.pistas == 4 && conversationStartNode == "Professor1") conversationStartNode = "Professor2";
        if (Input.GetKeyDown(KeyCode.Space)) StartConversation();
    }

    private void StartConversation()
    {
        if (distancia <= distanciaMax && interactable && !dialogueRunner.IsDialogueRunning)
        {
            isCurrentConversation = true;
            dialogueRunner.gameObject.SetActive(true);
            dialogueRunner.StartDialogue(conversationStartNode);
        }
    }

    private void EndConversation()
    {
        if (isCurrentConversation)
        {
            dialogueRunner.gameObject.SetActive(false);
            isCurrentConversation = false;
            if (isFirstTime)
            {
                isFirstTime = false;
                if (name != "Professor") interactable = false;
            }

            switch (name)
            {
                case "Pivô":
                    GameController.Instance.MostrarPolaroid(0);
                    GameController.Instance.pistas++;
                    break;
                case "Jogadores":
                    GameController.Instance.MostrarPolaroid(1); 
                    GameController.Instance.pistas++;
                    break;
                case "Professor":
                    if (conversationStartNode == "Professor1" && GameController.Instance.pistas == 4)
                    {
                        conversationStartNode = "Professor2";
                    }
                    else if (conversationStartNode == "Professor2")
                    {
                        GameController.Instance.MostrarPolaroid(2);
                        GameController.Instance.pistas++;
                        GameController.Instance.FuncaoTransicaoCena("EscolaInvertida");

                    }
                    break;
                case "Isaque Nilton":
                    GameController.Instance.MostrarPolaroid(3); 
                    GameController.Instance.pistas++;
                    break;
                case "Fran":
                    GameController.Instance.MostrarPolaroid(4); 
                    GameController.Instance.pistas++;
                    break;
            }
            dialogueRunner.gameObject.SetActive(false);
        }
        /*
        0 Foto do seu animal de estima��o (bola de basquete);
        1 Seu brinquedo favorito (fada);
        2 A foto de uma casa na �rvore;
        3 Uma foto do melhor amigo;
        4 Foto dos seus pais;
        */

    }

    public void OnMouseDown()
    {
        // if this character is enabled and no conversation is already running
        /*if (interactable && !dialogueRunner.IsDialogueRunning)
        {
            StartConversation();
        }*/
    }

}
