using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
