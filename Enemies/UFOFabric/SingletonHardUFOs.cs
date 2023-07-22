using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SingletonHardUFOs : MonoBehaviour, ISingletoneFabric
{
    public static SingletonHardUFOs instance;
    private List<GameObject> pooledUFOs = new List<GameObject>();
    private readonly int amountOfUf = 30;
    [SerializeField] public GameObject UFOpref;
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
        }
    }
    public GameObject GetPooledUFO()
    {
        return pooledUFOs.FirstOrDefault(t => !t.activeInHierarchy);
    }
    
    public void SetAllUfosDisabled()
    {
        foreach (var ufo in pooledUFOs)
        {
            ufo.SetActive(false);
        }
    }
}
