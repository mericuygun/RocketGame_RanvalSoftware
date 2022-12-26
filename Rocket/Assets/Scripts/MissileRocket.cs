using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileRocket : MonoBehaviour
{
    public GameObject effectExplosion;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(effectExplosion, gameObject.transform.position, Quaternion.identity);
            collision.collider.gameObject.SetActive(false);
        }
    }
}
