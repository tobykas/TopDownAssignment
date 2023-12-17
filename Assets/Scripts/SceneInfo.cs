using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "ScriptableObject")]
public class SceneInfo : ScriptableObject
{
    // Start is called before the first frame update
    public bool isNextScene = true;
}
