//using System.Collections.Generic;
//using UnityEngine;
//using Unity.Collections;
//using Unity.Jobs;
//using Unity.Burst;
//public class IJob_Image : MonoBehaviour
//{
//    public string[] texturePaths;

//    private void Start()
//    {
//        LoadTextures();
//    }

//    private void LoadTextures()
//    {
//        List<LoadTextureJob> jobs = new List<LoadTextureJob>();
//        NativeArray<JobHandle> jobHandles = new NativeArray<JobHandle>(texturePaths.Length, Allocator.Temp);

//        for (int i = 0; i < texturePaths.Length; i++)
//        {
//            LoadTextureJob job = new LoadTextureJob
//            {
//                texturePath = texturePaths[i]
//            };
//            jobs.Add(job);

//            jobHandles[i] = job.Schedule();
//        }

//        JobHandle.CompleteAll(jobHandles);
//        jobHandles.Dispose();
//    }

//    [BurstCompile]
//    struct LoadTextureJob : IJob
//    {
//        public string texturePath;

//        public void Execute()
//        {
//            Texture2D loadedTexture = LoadTextureFromFile(texturePath);
//            Debug.Log("Loaded texture: " + texturePath);
//        }

//        private Texture2D LoadTextureFromFile(string path)
//        {
//            byte[] bytes = System.IO.File.ReadAllBytes(path);
//            Texture2D texture = new Texture2D(2, 2);
//            texture.LoadImage(bytes);
//            return texture;
//        }
//    }
//}
