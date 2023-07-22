using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISingletoneFabric
{
    public void InitializePool();
    public GameObject GetPooledUFO();
}
