using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRocket : MonoBehaviour
{
    
    public GameObject rocket;
    public Quaternion targetRotation;
    public float targetRotationX;
    public float targetPositionZ;
    public Vector3 targetPosition;
    public Vector3 targetPositionCamera;
    public float speed;
    public float Velocity;
    public Camera mainCamera;
    

    public float limitX;
    public float xSpeed;

   
    // Start is called before the first frame update
    void Start()
    {
        
        targetRotationX = rocket.transform.eulerAngles.x;
        targetPositionZ = rocket.transform.position.z;
      
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(wait1sec());
    }

    IEnumerator wait1sec()
    {
          //ilerleme ve yunuslama icin taným
        

        targetRotationX -= Time.deltaTime * speed;
        //yunuslama
        targetRotation = Quaternion.Euler(targetRotationX, -90f, -90f);
        rocket.gameObject.transform.rotation = targetRotation;

         yield return new WaitForSeconds(3f);

            targetPositionZ += Time.deltaTime * Velocity;
        targetPosition = new Vector3(this.gameObject.transform.position.x, 1f, targetPositionZ);
        rocket.gameObject.transform.position = targetPosition;
        targetPositionCamera = new Vector3(0f, 4f, targetPositionZ - 3f);
        mainCamera.gameObject.transform.position = targetPositionCamera;
        // ilerleme

/*
        float newX = 0;
        float touchXDelta = 0;

        if(Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        targetPosition = new Vector3(newX, 1f, targetPositionZ);
        rocket.gameObject.transform.position = targetPosition;
*/
        
        

    }
}
