using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EventosPlayer : MonoBehaviour
{
    public bool naEscola;
    [SerializeField] private GameObject teto;
    private Tilemap tilemap;
    private Color originalColor;
    [SerializeField] GameObject polaroidsCorrompidos;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = teto.GetComponent<Tilemap>();
        originalColor = tilemap.color;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (naEscola && !teto.activeSelf)
        {
            // Start fade out if not already in process
            StartCoroutine(FadeOutTilemap());
        }
        else if (!naEscola && teto.activeSelf)
        {
            // Start fade in if not already in process
            StartCoroutine(FadeInTilemap());
        }*/
    }

    private IEnumerator FadeOutTilemap()
    {
        float duration = 1f; // Duration of fade
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / duration);
            tilemap.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tilemap.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        teto.SetActive(false);
    }

    private IEnumerator FadeInTilemap()
    {
        float duration = 1f; // Duration of fade
        float elapsedTime = 0f;

        teto.SetActive(true);
        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(0, 1, elapsedTime / duration);
            tilemap.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        tilemap.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Escola"))
        {
            StartCoroutine(FadeOutTilemap());
        }
        if (GameObject.Find("Polaroid Trigger") != null && collision.name == "Polaroid Trigger")
        {
            polaroidsCorrompidos.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Escola"))
        {
            StartCoroutine(FadeInTilemap());
        }
    }
}
