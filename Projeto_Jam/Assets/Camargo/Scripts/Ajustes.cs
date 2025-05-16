using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ajustes : MonoBehaviour
{
    [SerializeField] TMP_Dropdown opcaoDaltonismo;
    [SerializeField] GameObject[] filtros;
    [SerializeField] Slider musicaSlider;
    [SerializeField] Slider efeitoSlider;
    [SerializeField] private AudioSource mscsrc;
    [SerializeField] private AudioSource sfxsrc;
    
    void Awake()
    {
      if (GameObject.Find("MenuManager")==null) 
      {
        mscsrc = GameController.Instance.mscsrc;
        sfxsrc = GameController.Instance.sfxsource;
      }
    }

    // Update is called once per frame
    void Update()
    {
        if (mscsrc != null && musicaSlider != null)
        {
          mscsrc.volume = musicaSlider.value;
        }

        if (sfxsrc != null && efeitoSlider != null)
        {
          sfxsrc.volume = efeitoSlider.value;
        }
    }
    
    public void TrocarFiltroDaltonismo()
    {
      for (int i = 0; i < filtros.Length; i++)
      {
        if (opcaoDaltonismo.value == i) filtros[i].SetActive(true);
        else filtros[i].SetActive(false);
      }
    }
}
