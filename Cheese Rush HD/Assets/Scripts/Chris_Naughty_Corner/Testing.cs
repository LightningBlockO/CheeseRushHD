using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Collections;
using Newtonsoft.Json;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Burst;

public class Testing : MonoBehaviour
{
    [SerializeField] private bool useJobs;
    private void Update()
    {
        float startTime = Time.realtimeSinceStartup;
        if (useJobs)
        {
            NativeList<JobHandle> jobHandleList = new NativeList<JobHandle>(Allocator.Temp);
            for (int i = 0; i < 10; i++)
            {
                JobHandle jobHandle = ReallyToughTaskJob();
                jobHandleList.Add(jobHandle);
            }
            JobHandle.CompleteAll(jobHandleList);
            jobHandleList.Dispose();
        }
        else
        {
            for (int i = 0; i <10; i++)
            {
                ReallyToughTask();
            }
            
        }
        Debug.Log(((Time.realtimeSinceStartup - startTime) * 1000f) + "ms");
    }

    private void ReallyToughTask()
    {
        float value = 0f;
        for (int i = 0; i < 5000; i++)
        {
            value = math.exp10(math.sqrt(value));
        }
    }
    private JobHandle ReallyToughTaskJob()
    {
        ReallyToughJob job = new ReallyToughJob();
        return job.Schedule();
    }

    
}
[BurstCompile]
public struct ReallyToughJob : IJob
{
    public void Execute()
    {
        float value = 0f;
        for (int i = 0; i < 5000; i++)
        {
            value = math.exp10(math.sqrt(value));
        }
    }
}

