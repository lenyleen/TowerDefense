using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrpt : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnEnable()
    {
        if(this.gameObject.GetComponent<TrailRenderer>() != null)
            this.gameObject.GetComponent<TrailRenderer>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BaseUfo>() != null)
        {
            collision.gameObject.GetComponent<BaseUfo>().hp -= damage;
        }
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if (this.gameObject.GetComponent<TrailRenderer>() != null)
            this.gameObject.GetComponent<TrailRenderer>().enabled = false;
    }
}
