using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameOverScene : MonoBehaviour
{

    public void ChangeToLoseScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }

}
