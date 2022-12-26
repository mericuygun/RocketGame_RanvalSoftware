using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemMove : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public GameObject enemy;
    public float x,y,z;
    public Vector3 mesafe;
    public float min;
    public bool hareket=false;

    private void Start()
    {
        x = player.transform.position.x - this.transform.position.x;
        y = player.transform.position.y - this.transform.position.y;
        z = player.transform.position.z - this.transform.position.z;
      
    }

    private void Update()
    {


        x = player.transform.position.x - this.transform.position.x;
        y = player.transform.position.y - this.transform.position.y;
        z = player.transform.position.z - this.transform.position.z;
        mesafe=new Vector3(x,y,z);
        Debug.Log(mesafe.magnitude);
        if (mesafe.magnitude < min && hareket==false)
        {
        
         
         this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
          
        }
        else if(mesafe.magnitude >min && hareket == false)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - speed * Time.deltaTime);
        }
        if (player.transform.position.z > this.transform.position.z)
        {
            hareket = true; 

        }
        
        Debug.Log(player.transform.position.z-this.transform.position.z);
    }
   
}

