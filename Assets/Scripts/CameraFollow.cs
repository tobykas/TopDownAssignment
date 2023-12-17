using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Variables
    private static CameraFollow instance;
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
        if (target != null)
        {
            PosX = target.transform.position.x;
            PosY = target.transform.position.y;
        }

        transform.position = new Vector3(PosX, PosY, -1);
    }

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void MoveCamera()
    {
        if (isOn == true)
        {
            if (target)
            {
                targetPosX = target.transform.position.x;
                targetPosY = target.transform.position.y;
                
                if (targetPosX > maxRight) 
                {
                    PosX = maxRight;
                }

                else if (targetPosX < maxLeft)
                {
                    PosX = maxLeft;
                }
                else 
                {
                    PosX = targetPosX;
                }


                if (targetPosY > maxTop)
                {
                    PosY = maxTop;
                }
                else if (targetPosY < maxBottom)
                {
                    PosY = maxBottom;
                }
                else 
                {
                    PosY = targetPosY;
                }
                
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
