using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nomeDaFase;
    public GameObject settings;
    public GameObject credits;
    public GameObject mainMenu;
    public AudioClip giz;
    public void Play()
    {
        SceneManager.LoadScene(nomeDaFase);
    }
    public void OpenSettings()
    {
        print("nuiqdq");
        mainMenu.SetActive(false);
        settings.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(giz);
    }
    public void CloseSetting()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(giz);
    }
    public void OpenCredits()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(giz);
    }
    public void CloseCredits()
    {
        credits.SetActive(false);   
        mainMenu.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(giz);
    }
    public void Exit()
    {
        GetComponent<AudioSource>().PlayOneShot(giz);
        Application.Quit();
    }
}
