using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private int team;

    private LayerMask ballLayerMask;

    private void Awake()
    {
        ballLayerMask = LayerMask.NameToLayer("Ball");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if triggering object is a ball
        if (other.gameObject.layer != ballLayerMask)
            return;

        scoreManager.ScoreGoal(team);
    }
}