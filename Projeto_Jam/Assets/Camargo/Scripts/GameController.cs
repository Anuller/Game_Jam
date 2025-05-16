using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEditor.Rendering;
using Yarn.Unity;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public AudioSource mscsrc, sfxsource;
    public AudioClip musicaMenu, musicaIntro, musicaEscola, musicaFim, dialogo, win, somTransicao, vozes;
    [SerializeField] TMP_Dropdown opcaoDaltonismo;
    [SerializeField] GameObject[] filtros;
    public TextMeshProUGUI pistasUI;
    public int pistas;
    [SerializeField] GameObject polaroid, menuAjustes;
    [SerializeField] Image polaroidImage;
    [SerializeField] Sprite[] polaroids;
    public bool podeAndar = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if ((GameObject.Find("Dialogue System") != null) && GameObject.Find("Dialogue System").GetComponent<DialogueRunner>().IsDialogueRunning || (polaroid != null && polaroid.activeSelf))
        { 
            podeAndar = false; 
        }
        else podeAndar = true;

        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab)) && GameObject.Find("MenuManager")==null) //nao está no menu
        {
            menuAjustes.gameObject.SetActive(!menuAjustes.gameObject.activeSelf);
        }
    }

    public void FuncaoTransicaoCena(string cena)
    {
        StartCoroutine(TransicaoCena(cena));
    }
    public IEnumerator TransicaoCena(string cena)
    {
        sfxsource.PlayOneShot(somTransicao);
        yield return new WaitForSeconds(5);
        CarregarCena(cena);
    }

    public void CarregarCena(string nome)
    {
        SceneManager.LoadScene(nome);
    }

    public void TrocarFiltroDaltonismo()
    {
      for (int i = 0; i <= filtros.Length; i++)
      {
        if (opcaoDaltonismo.value == i) filtros[i].SetActive(true);
        else filtros[i].SetActive(false);
      }
    }

    public void SomDialogo()
    {
        sfxsource.PlayOneShot(dialogo);
    }


    public void MostrarPolaroid(int indice)
    {
        StartCoroutine(FadePolaroid(polaroids[indice]));
    }

    IEnumerator FadePolaroid(Sprite newSprite)
    {
        // Fade out
        yield return StartCoroutine(Fade(0f));

        // Muda o sprite
        polaroidImage.sprite = newSprite;

        // Torna o polaroid vis�vel
        polaroid.SetActive(true);

        // Fade in
        yield return StartCoroutine(Fade(1f));

        sfxsource.PlayOneShot(win);
        pistasUI.text = $"Pistas\n{pistas}/5";
        // Espera por 3 segundos
        yield return new WaitForSeconds(3);


        // Fade out novamente antes de desativar
        yield return StartCoroutine(Fade(0f));

        // Desativa o polaroid
        polaroid.SetActive(false);
        
    }

    IEnumerator Fade(float targetAlpha)
    {
        Color startColor = polaroidImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);
        float elapsedTime = 0f;

        while (elapsedTime < 1)
        {
            elapsedTime += Time.deltaTime;
            polaroidImage.color = Color.Lerp(startColor, endColor, elapsedTime / 1);
            yield return null;
        }

        polaroidImage.color = endColor;
    }
}