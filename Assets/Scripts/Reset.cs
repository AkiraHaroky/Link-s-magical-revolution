using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void ResetFight()
    {
        SceneManager.LoadScene("Fight_1");
    }

    public void ResetFight_2()
    {
        SceneManager.LoadScene("Fight_2");
    }

    public void ResetFight_3()
    {
        SceneManager.LoadScene("Fight_3");
    }

    
}
