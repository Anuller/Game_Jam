using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public enum Stage
    {
        WaitingToStart,
        Stage_1,
        Stage_2, 
        Stage_3,
    }

    [SerializeField]
    private tirggerEnemy triggerCollider;

    [SerializeField]
    private EnemySpawn pfEnemySpawn;

    public Transform[] spawnPointList;

    [SerializeField]
    private BossHealth bossLive;

    private List<EnemySpawn> spawnList;

    private Stage stage;

    public GameObject hands;

    public GameObject balls;

    public GameObject storm;

    public Animator animator;

    private void Awake()
    {
        /*spawnPointList = new List<Vector3>();
        foreach (Transform spawnPostion in transform.Find("SpawnPosition"))
        {
            spawnPointList.Add(spawnPostion.position);
        }*/

        stage = Stage.WaitingToStart;
    }

    void Start()
    {
        triggerCollider.OnPlayerEnterTrigger += tirggerEnemy_OnPlayerEnterTrigger;

        hands.SetActive(false);

        balls.SetActive(false);

        storm.SetActive(false);
    }

    public void OnDeadAnim()
    {
        animator.SetBool("Dead", true);
        GameController.Instance.FuncaoTransicaoCena("Fim");
    }

    private void Update()
    {
        switch (stage)
        {
            case Stage.Stage_1:
                if (bossLive.currentHealth <= 70f)
                {
                    StartNextStage();
                }
                break;

            case Stage.Stage_2:
                if (bossLive.currentHealth <= 30f)
                {
                    StartNextStage();
                }
                break;
            case Stage.Stage_3:
                if (bossLive.currentHealth <= 0f)
                {
                    OnDeadAnim();
                }
                break;
        }
    }

    void StartNextStage()
    {
        switch (stage)
        {
            case Stage.WaitingToStart:
                stage = Stage.Stage_1;
                hands.SetActive(true);
                break;

            case Stage.Stage_1:
                stage = Stage.Stage_2;
                balls.SetActive(true);
                break;

            case Stage.Stage_2:
                stage = Stage.Stage_3;
                storm.SetActive(true);
                break;
        }
        Debug.Log("Starting next stage: " + stage);
    }

    private void tirggerEnemy_OnPlayerEnterTrigger(object sender, EventArgs e)
    {
        
        StartBattle();
        triggerCollider.OnPlayerEnterTrigger -= tirggerEnemy_OnPlayerEnterTrigger;
    }

    private void StartBattle()
    {
        Debug.Log("Start");
        StartNextStage();
        SpawnEnemy();
    }


    void SpawnEnemy()
    {
        for (int i = 0; i < spawnPointList.Length; i++)
        {
            spawnPointList[i].gameObject.SetActive(true);
        }
    }
}
