using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SingletonUFOs : MonoBehaviour,ISingletoneFabric
{
    public static SingletonUFOs instance;
    private List<GameObject> pooledUFOs = new List<GameObject>();
    private readonly int amountOfUf = 30;
    private List<GameObject> coinPool = new List<GameObject>();
    private List<GameObject> heartPool = new List<GameObject>();
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject UFOpref;
    [SerializeField] private GameObject heart;
    private void OnEnable()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        InitializePool();   
    }

    public void InitializePool()
    {
        for (var i = 0; i < amountOfUf; i++)
        {
            var obj = Instantiate(UFOpref,this.transform);
            obj.SetActive(false);
            pooledUFOs.Add(obj);
            if (i % 3 != 0) continue;
            var heartObj = Instantiate(heart,this.transform);
            var coinObj = Instantiate(coin,this.transform);
            heartObj.SetActive(false);
            coinObj.SetActive(false);
            heartPool.Add(heartObj);
            coinPool.Add(coinObj);
        }

    }
    public GameObject GetPooledUFO()
    {
        return pooledUFOs.FirstOrDefault(t => !t.activeInHierarchy);
    }

    public GameObject GetCoin(Transform sender)
    {
        var coinToReturn = coinPool.FirstOrDefault(t => !t.activeInHierarchy);
        coinToReturn.transform.position = sender.position;
        return coinToReturn;
    }

    public GameObject GetHeart(Transform sender)
    {
        var Heart = heartPool.FirstOrDefault(t => !t.activeInHierarchy);
        Heart.transform.position = sender.position;
        return Heart;
    }

    public void SetAllUfosDisabled()
    {
        foreach (var ufo in pooledUFOs)
        {
            ufo.SetActive(false);
        }
    }
}
