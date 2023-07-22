using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    private readonly List<GameObject> pooledBull = new List<GameObject>();
    private readonly List<GameObject> arrowPool = new List<GameObject>();
    private readonly List<GameObject> stonePool = new List<GameObject>();
    private int amountOfBull = 30;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject arrow;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < amountOfBull; i++)
        {
            var obj = Instantiate(bulletPref,this.transform);
            var stoneObj = Instantiate(stone, this.transform);
            var arrowObj = Instantiate(arrow, this.transform);
            stoneObj.SetActive(false);
            arrowObj.SetActive(false);
            obj.SetActive(false);
            arrowPool.Add(arrowObj);
            stonePool.Add(stoneObj);
            pooledBull.Add(obj);
        }
    }

    public GameObject GetBullet(Transform sender)
    {
        var obj = pooledBull.FirstOrDefault(t => !t.activeInHierarchy);
        obj.transform.position = sender.position;
        return obj;
    }

    public GameObject GetArrow(Transform sender)
    {
        var obj = arrowPool.FirstOrDefault(t => !t.activeInHierarchy);
        obj.transform.position = sender.position;
        return obj;
    }

    public GameObject GetStone(Transform sender)
    {
        var obj = stonePool.FirstOrDefault(t => !t.activeInHierarchy);
        obj.transform.position = sender.position;
        return obj;
    }
}
