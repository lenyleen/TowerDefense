using UnityEngine;
using System;
public class MoveOfTower : MonoBehaviour

{
    private GameObject tower;
    private readonly Vector3 centerOfTileGrid = new Vector3(4f, 0.75f, -1.5f);
    private void OnEnable()
    {
        GreenHighlightState.drop += TowerDropped;
    }
    public void GetTower(GameObject Tower)
    {
        if(tower != null) Destroy(tower.gameObject);
        tower = Instantiate(Tower,centerOfTileGrid,Quaternion.identity);
    }
    private void TowerDropped()
    {
        tower = null;
    }
    
}
