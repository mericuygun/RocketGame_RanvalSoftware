using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CharacterAttack : MonoBehaviour
{
    GameObject _Player;
    public GameObject objectRocket;
    public GameObject objectEnemy;
    GameObject _objectMissileRocket;    
    bool IsFired;
    void Start()
    {
        _Player = this.gameObject;        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    IsFired = true;
                    objectEnemy = hit.transform.gameObject;
                    _objectMissileRocket = Instantiate(objectRocket, _Player.transform.position, Quaternion.identity);
                    StartCoroutine(HommingMissile());
                }
            }
        }
        
    }
    IEnumerator HommingMissile()
    {
        yield return null;
        _objectMissileRocket.transform.DOMove(objectEnemy.transform.position, 0.5f);
        _objectMissileRocket.transform.LookAt(objectEnemy.transform);
        //yield return new WaitForSeconds(5);
        //Object.Destroy(_objectMissileRocket);
        //IsFired = false;

    }
}
