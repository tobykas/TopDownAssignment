using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterScene : MonoBehaviour
{
    public GameObject entrance;
    public GameObject exit;

    [SerializeField]
    public SceneInfo sceneInfo;

    public Vector3 offsetEntrance = new Vector3(1.0f, 0.5f, 0.0f);
    public Vector3 offsetExit = new Vector3(-1.0f, 0.5f, 0.0f);
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        entrance = GameObject.FindGameObjectWithTag("EntranceScene");
        exit = GameObject.FindGameObjectWithTag("ExitScene");

        GameObject target = sceneInfo.isNextScene ? entrance : exit;
        Vector3 offset = sceneInfo.isNextScene ? offsetEntrance : offsetExit;

        rb.position = target.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
