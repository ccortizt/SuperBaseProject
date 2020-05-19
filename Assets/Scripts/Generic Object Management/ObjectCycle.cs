using System.Collections;
using UnityEngine;

public class ObjectCycle : MonoBehaviour
{
    [SerializeField] MoveDir[] directions;
    [SerializeField] float transitionSpeed = 1;
    [SerializeField] int numCycles = 10;
    [SerializeField] float size = 1; // object to move scale 1m default as a cube

    void Start()
    {
        StartCoroutine(DoCycle());
    }


    IEnumerator DoCycle()
    {
        if (numCycles != 0)
        {
            for (int k = 0; k < numCycles; k++)
            {
                for (int i = 0; i < directions.Length; i++)
                {
                    StartCoroutine(MakeTransition(SetDir(directions[i])));
                    yield return new WaitForSeconds(2f * (size / transitionSpeed));
                }
            }
        }
        else
        {
            while (gameObject.activeSelf)
            {
                for (int i = 0; i < directions.Length; i++)
                {
                    StartCoroutine(MakeTransition(SetDir(directions[i])));
                    yield return new WaitForSeconds(2f * (size / transitionSpeed));
                }
            }
        }



    }

    IEnumerator MakeTransition(Vector3 transitionDirection)
    {
        for (int i = 0; i < 100 / transitionSpeed; i++)
        {
            yield return new WaitForSeconds(size / (100f * transitionSpeed));
            transform.Translate(transitionDirection * (size * transitionSpeed / 100f), transform);
        }
    }


    public Vector3 SetDir(MoveDir dir)
    {
        switch (dir)
        {
            case MoveDir.up:
                return Vector3.forward;

            case MoveDir.down:
                return Vector3.back;

            case MoveDir.left:
                return Vector3.left;

            case MoveDir.right:
                return Vector3.right;

            default:
                return Vector3.zero;
        }


    }
}

public enum MoveDir
{

    up, down, left, right

}
