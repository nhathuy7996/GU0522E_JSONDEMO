using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorkerMainThread : MonoBehaviour
{
    public static Queue<Action> listTask = new Queue<Action>();

    // Update is called once per frame
    void Update()
    {
        while (listTask.Count != 0)
        {
            listTask.Dequeue()?.Invoke();
        }
    }
}
