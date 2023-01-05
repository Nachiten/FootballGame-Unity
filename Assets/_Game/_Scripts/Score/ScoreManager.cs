using Unity.Netcode;
using UnityEngine;

public class ScoreManager : NetworkBehaviour
{
    [SerializeField] private ScoreManagerUI scoreManagerUI;

    // This data is only stored on the server
    private int teamLeftScore;
    private int teamRightScore;
    
    public override void OnNetworkSpawn()
    {
        GetScoreServerRpc();
    }

    public void ScoreGoal(int team)
    {
        ScoreGoalServerRpc(team);
    }

    [ServerRpc(RequireOwnership = false)]
    private void GetScoreServerRpc()
    {
        SetScoreClientRpc(teamLeftScore, teamRightScore);
    }
    
    [ServerRpc(RequireOwnership = false)]
    private void ScoreGoalServerRpc(int team)
    {
        if (team == 0)
            teamLeftScore++;
        else
            teamRightScore++;

        SetScoreClientRpc(teamLeftScore, teamRightScore);
    }

    [ClientRpc]
    private void SetScoreClientRpc(int newTeamLeftScore, int newTeamRightScore)
    {
        scoreManagerUI.UpdateGoals(newTeamLeftScore, newTeamRightScore);
    }
}