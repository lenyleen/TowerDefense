using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TutorialSpawner : MonoBehaviour
{ 
   [SerializeField] private TalkingHeadTips tips;
   private List<ButtonScript> Buttons = new List<ButtonScript>();
   [SerializeField]private GameObject hearth;
   [SerializeField]private GameObject coin;
   private ISingletoneFabric ufoFabric;
   [SerializeField] private float delayOfSpawn;
   [SerializeField] private Transform spawnPosition;
   [SerializeField] private UI_Manager manager;
   private void OnEnable()
   {
      Buttons.AddRange(FindObjectsOfType<ButtonScript>(true));
      ufoFabric = SingletonUFOs.instance;
      tips.tipsAction += HideAll;
      HeartMove.AddColectible += OnHearthReduce;
      TestMover.addColectible += OnCoinIncrease;
   }

   private void Start()
   {
      StartMessaging(TalkingHeadTalkingScript.StarMessage);
      StartCoroutine(SpawnUfo(1f));
   }

   private IEnumerator SpawnUfo(float speed) 
   {
      yield return new WaitForSeconds(delayOfSpawn);
      ParticleAnimation(spawnPosition);
      yield return new WaitForSeconds(0.5f);
      var UFO = ufoFabric.GetPooledUFO();
      UFO.transform.position = spawnPosition.position;
      UFO.transform.eulerAngles = spawnPosition.transform.eulerAngles;
      UFO.GetComponent<NavMeshAgent>().speed = speed;
      UFO.SetActive(true);
   }

   private IEnumerator SpawnCoupleUfos()
   {
      for (var i = 0; i < 4; i++)
      {
         yield return StartCoroutine(SpawnUfo(0.5f));
      }
      StartMessaging(TalkingHeadTalkingScript.LastMessage);
      yield return new WaitForSeconds(7f);
      StartMessaging(TalkingHeadTalkingScript.PS);
      yield return new WaitForSeconds(20f);
      manager.ActivateWinPanel();
   }
   private void OnCoinIncrease()
   {
      coin.gameObject.SetActive(true);
      StartMessaging(TalkingHeadTalkingScript.ShowCoinIncrease);
      TestMover.addColectible -= OnCoinIncrease;
   }

   private void OnHearthReduce()
   {
      hearth.gameObject.SetActive(true);
      StartMessaging(TalkingHeadTalkingScript.ShowHpReduceMessage);
      HeartMove.AddColectible -= OnHearthReduce;
      coin.gameObject.SetActive(true);
      tips.tipsAction += ShowUsageOfTowers;
   }

   private void StartMessaging(string message)
   { 
      tips.transform.parent.gameObject.SetActive(true);
      tips.ShowMessage(message);
   }

   private void ShowUsageOfTowers()
   {
      StartMessaging(TalkingHeadTalkingScript.ShowUsageOfTowers);
      foreach (var button in Buttons)
      {
         button.gameObject.SetActive(true);
      }
      tips.tipsAction -= ShowUsageOfTowers;
      StartCoroutine(SpawnCoupleUfos());
   }
   private void HideAll()
   {
      tips.transform.parent.gameObject.SetActive(false);
   }
   private async void ParticleAnimation(Transform spawnPos)
   {
      spawnPos?.GetChild(1).GetComponent<ParticleSystem>().Play();
      await Task.Delay(1000);
      spawnPos?.GetChild(1).GetComponent<ParticleSystem>().Stop();
   }
}
