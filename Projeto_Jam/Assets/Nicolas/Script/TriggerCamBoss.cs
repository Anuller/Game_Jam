using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCamBoss : MonoBehaviour
{
    public GameObject camPlayer, BossActive, fightDialogue;
    public GameObject ambiente;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossCam"))
        {
            camPlayer.SetActive(false);
            BossActive.SetActive(true);
            fightDialogue.SetActive(true);
            ambiente.SetActive(false);
            GameController.Instance.sfxsource.clip = GameController.Instance.vozes;
            GameController.Instance.sfxsource.loop = true;
            GameController.Instance.sfxsource.Play();
        }
    }
}
