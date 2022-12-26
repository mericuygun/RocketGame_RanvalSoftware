using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingCylinder : MonoBehaviour
{
    public GameObject playerController;
    private bool _fiiled;
    private float _value;
    private int x = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("charracter");
        
    }
    public void IncrementCylinderVolume(float value)
    {
        _value += value;

        x += 1;

        if (x >= 3)
        {
            PlayerPrefs.SetInt("Guc", PlayerPrefs.GetInt("Guc") - 1);
            x = 0;
        }

        /*
        if (_value > 1)
        {
            float leftvalue = _value - 1;
            int cylindercount = playerController.GetComponent<PlayerController>().cylinders.Count;
            transform.localPosition = new Vector3(transform.localPosition.x +5 , -0.5f * (cylindercount - 1) - 0.25f, transform.localPosition.z);
            transform.localScale = new Vector3(0.5f, transform.localScale.y, 0.5f);
            playerController.GetComponent<PlayerController>().CreatCylinder(leftvalue);  // 1'den ne kadar büyükse o büyüklükte bir silindir yarat.
        }
        else if (_value < 0)
        {
            playerController.GetComponent<PlayerController>().DestroyCylinder(this);
            // karakterimize bu silindiri yok etmesini söyle
        }
        else
        {
            int cylindercount = playerController.GetComponent<PlayerController>().cylinders.Count;
            transform.localPosition = new Vector3(transform.localPosition.x + 5, -0.5f * (cylindercount - 1) - 0.25f * _value, transform.localPosition.z);
            transform.localScale = new Vector3(0.5f * _value, transform.localScale.y, 0.5f * _value);
            // silindirin boyutunu güncelleyeceðiz.
        }
        */
    }
}
