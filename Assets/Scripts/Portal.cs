using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private string nextSceneNumber;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string nextSceneName = nextSceneNumber.ToString();

        SceneManager.LoadScene(nextSceneName);
    }
}
