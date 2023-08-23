using System.Collections;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Burst;
using Dan.Main;

public class IJob_LoadScore : MonoBehaviour
{
    [BurstCompile]
    struct InitializationJob : IJob
    {
        public void Execute()
        {
            // Load the high score system during initialization
            LoadHighScoreSystem();

            // Other initialization tasks can also be added here
        }

        private void LoadHighScoreSystem()
        {
            // Use the LeaderBoard script logic here to load the high scores
            LeaderBoard leaderBoard = new LeaderBoard();
            leaderBoard.GetLeaderboard();
        }
    }

    private void Start()
    {
        StartCoroutine(InitializeGameWithJob());
    }

    private IEnumerator InitializeGameWithJob()
    {
        // Create the InitializationJob instance
        InitializationJob initializationJob = new InitializationJob();

        // Schedule the job
        JobHandle initializationJobHandle = initializationJob.Schedule();

        // Wait for the job to complete
        yield return new WaitWhile(() => !initializationJobHandle.IsCompleted);

        Debug.Log("Game initialization complete.");
    }
}
