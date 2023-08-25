//using System.Collections;
//using UnityEngine;
//using Unity.Jobs;
//using Unity.Collections;
//using Unity.Burst;
//using Dan.Main;

//public class IJob_LoadScore : MonoBehaviour
//{
//    [BurstCompile]
//    struct InitializationJob : IJob
//    {
//        public void Execute()
//        {
//            LoadHighScoreSystem();
//        }

//        private void LoadHighScoreSystem()
//        {
//            LeaderBoard leaderBoard = new LeaderBoard();
//            leaderBoard.GetLeaderboard();
//        }
//    }

//    private void Start()
//    {
//        StartCoroutine(InitializeGameWithJob());
//    }

//    private IEnumerator InitializeGameWithJob()
//    {
//        InitializationJob initializationJob = new InitializationJob();
//        JobHandle initializationJobHandle = initializationJob.Schedule();
//        yield return new WaitWhile(() => !initializationJobHandle.IsCompleted);
//        Debug.Log("Game initialization complete.");
//    }
//}
