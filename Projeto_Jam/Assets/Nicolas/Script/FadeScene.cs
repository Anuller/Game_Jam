using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour
{
    [Header("Referencias")]

    [Tooltip("Objeto de transição")]
    public GameObject FadePrefab;

    [Tooltip("Tempo do tansição")]
    public float timeEnd;

    [Tooltip("Nome da proxima cena")]
    public string nameScene;

    IEnumerator TimeFade()
    {
            yield return new WaitForSeconds(timeEnd);
            SceneManager.LoadScene(nameScene);
    }

    private void Update()
    {
        if (FadePrefab != null)
        {
            StartCoroutine(TimeFade());
        }
    }
}
