using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

public class TaskDemo : MonoBehaviour
{
    [SerializeField] GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //new Task(()=> {

            //    double sum = 0;
            //    for (int i = 0; i < 10000; i++)
            //    {
            //        Debug.Log(i);
            //        sum += i;
            //    }

            //    Debug.LogError("Show up");

            //    WorkerMainThread.listTask.Enqueue(() =>
            //    {

            //        obj.SetActive(true);
            //    });

            //    Debug.LogError("Show up done!");

            //}).Start();

            new Task(calculateSum).Start();
    }

    }

    void calculateSum()
    {
        double sum = 0;
        for (int i = 0; i < 10000; i++)
        {
            Debug.Log(i);
            sum += i;
        }

        Debug.LogError("Show up");

        WorkerMainThread.listTask.Enqueue(() =>
        {

            obj.SetActive(true);
        });

        Debug.LogError("Show up done!");
    }
}
