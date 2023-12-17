using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenesmanager : MonoBehaviour
{
    public int sceneIndex;
    public bool isNextScene = true;

    [SerializeField]
    public SceneInfo sceneInfo;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            sceneInfo.isNextScene = isNextScene;
            if (isNextScene) 
            {
                SceneManager.LoadScene(sceneIndex);
            }       
        }
    }
}
