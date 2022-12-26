using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movee : MonoBehaviour
{
    private float rotateX = 0;
    public float rotatingSpeed;

    void Update()
    {


        if (PlayerPrefs.GetInt("oyunsuruyor") == 1)
        {
            rotateX += 1;
            this.gameObject.transform.rotation = Quaternion.Euler((this.transform.rotation.x - rotateX)*rotatingSpeed, -90, -90);
        }

    }
}
