using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject UFO;
    public List<GameObject> UFOcount;
    private SpawnStateMachine SM;
    private FWawe fw;
    public SWawe sw;
    public TWawe tw;
    public FrWawe frW;
    public EndState endState;
    public readonly ConcurrentBag<Transform> spawnPositions = new ConcurrentBag<Transform>();
    public ISingletoneFabric ufoFabric;
    public float delayOfSpawn = 6f;
    public Action spawnerAction;
    public GameObject alertFade;
    
    private void OnEnable()
    {
        GreenHighlightState.drop += InitializeWaves;
        alertFade = FindObjectOfType<SpawnAlert>(true).gameObject; 
    }

    private void Update()
    {
        SM?.CurrentState.LogicUpdate();                                                                                 //Проверка на null, потому что CurrentState может быть не инициализирован
    }

    private void InitializeWaves()
    {
        SM = new SpawnStateMachine();
        fw = new FWawe(this, SM, UFO);
        sw = new SWawe(this, SM, UFO);
        tw = new TWawe(this, SM, UFO);
        frW = new FrWawe(this, SM, UFO);
        endState = new EndState(this, SM, UFO);
        SM.Initialize(fw);
        spawnerAction?.Invoke();
        GreenHighlightState.drop -= InitializeWaves;
    }
    public IEnumerator SpawnFWave()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            foreach (var spawnPos in spawnPositions)
            {
                yield return new WaitForSeconds(delayOfSpawn);
                ParticleAnimation(spawnPos);
                yield return new WaitForSeconds(0.5f);
                var UFO = ufoFabric.GetPooledUFO();
                UFOcount.Add(UFO);
                UFO.transform.position = spawnPos.position;
                UFO.transform.eulerAngles = spawnPos.transform.eulerAngles;
                UFO.SetActive(true);
            }
        }
    }
    private async void ParticleAnimation(Transform spawnPos)
    {
        spawnPos?.GetChild(1).GetComponent<ParticleSystem>().Play();
        await Task.Delay(1000);
        spawnPos?.GetChild(1).GetComponent<ParticleSystem>().Stop();
    }

    private void OnDisable()
    {
        GreenHighlightState.drop -= InitializeWaves;
    }
}
