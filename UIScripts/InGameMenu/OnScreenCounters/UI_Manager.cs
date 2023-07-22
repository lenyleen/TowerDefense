using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
     [SerializeField] private GameObject WinPanel;
     public GameObject LosePanel;
     private EnemySpawn spawner;
     List<BaseUfo> lastUfos = new List<BaseUfo>();
     private void OnEnable()
     {
          LifeCounter.healthAction += ActivateLosePanel;
          spawner = GameObject.FindObjectOfType<EnemySpawn>();
          spawner.spawnerAction += InitializeSpawner;
     }

     private void InitializeSpawner()
     {
          spawner.frW.waveAction += GetLastUfo;
          spawner.spawnerAction -= InitializeSpawner;
     }

     public void ActivateWinPanel()
     {
          SingletonUFOs.instance.SetAllUfosDisabled();
          SingletonHardUFOs.instance?.SetAllUfosDisabled();
          Time.timeScale = 0;
          WinPanel.SetActive(true);
          if (PlayerPrefs.GetInt("levelReached") <= Convert.ToInt32(SceneManager.GetActiveScene().name))
          {
               PlayerPrefs.SetInt("levelReached",Convert.ToInt32(SceneManager.GetActiveScene().name) + 1);
          }
     }

     private void ActivateLosePanel()
     {
          SingletonUFOs.instance.SetAllUfosDisabled();
          SingletonHardUFOs.instance.SetAllUfosDisabled();
          Time.timeScale = 0;
          LosePanel.SetActive(true);
     }

     private void GetLastUfo()
     {
          lastUfos.AddRange(FindObjectsOfType<BaseUfo>());
          foreach (var ufo in lastUfos)
          {
               ufo.onDest.ufoAction += RemoveUfosFromEnumerator;
          }
     }

     private void RemoveUfosFromEnumerator(BaseUfo ufo)
     {
          lastUfos.Remove(ufo);
          if(lastUfos.Count < 1)
               ActivateWinPanel();
     }
}
