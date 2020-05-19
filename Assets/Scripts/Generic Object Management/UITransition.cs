using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UITransition : MonoBehaviour
{


    void Start()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        MakeTransition(0);
    }

    private void LoadNextlevel()
    {

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            MakeTransition(1, () => SceneManager.LoadScene(nextLevel));
        }

    }

    private void Update()
    {
        //TEST ONLY!
        if (Input.GetMouseButton(0))
        {
            LoadNextlevel();
        }
    }


    void MakeTransition(int endAlpha, Action endAction = null)
    {
        DOTween.To(() => GetComponent<CanvasGroup>().alpha, x => GetComponent<CanvasGroup>().alpha = x, endAlpha, 1).OnComplete(() => endAction());
    }


}
