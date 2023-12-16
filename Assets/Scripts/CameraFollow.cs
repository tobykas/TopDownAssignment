using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables
    public GameObject target;

    //Variables privadas para matematicas
    private float targetPosX;
    private float targetPosY;

    private float PosX;
    private float PosY;

    public float maxRight;
    public float maxLeft;

    public float maxTop;
    public float maxBottom;

    public float speed;
    public bool isOn = true;

    void Awake()
    {
        PosX = targetPosX;
        PosY = targetPosY;
        transform.position = new Vector3(PosX, PosY, -1);
    }

    void MoveCamera()
    {
        if (isOn == true)
        {
            if (target)
            {
                targetPosX = target.transform.position.x;
                targetPosY = target.transform.position.y;

                PosX = targetPosX;
                /*
                if (targetPosX > maxRight && targetPosX < maxLeft) 
                {
                    PosX = targetPosX;
                }
                */

                PosY = targetPosY;
                /*
                if (targetPosY < maxTop && targetPosY > maxBottom) 
                {
                    PosY = targetPosY;
                }
                */
            }
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(PosX, PosY, -1), speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        MoveCamera();
    }
}
