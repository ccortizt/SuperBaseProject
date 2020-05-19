using System;
using UnityEngine;

public class TestCallBack : MonoBehaviour
{

    private Action actionToDo;
    bool someCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        Test(PrintB);
    }

    // Update is called once per frame
    void Update()
    {
        if (someCondition)//something like time running down
            actionToDo?.Invoke();
    }


    void Test(Action t = null)
    {
        PrintA();
        actionToDo = t;
    }


    void PrintA()
    {
        print("a");
    }

    void PrintB()
    {
        print("b");
    }


}
