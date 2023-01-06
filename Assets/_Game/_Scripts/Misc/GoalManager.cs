using UnityEngine;
using UnityEngine.Serialization;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [FormerlySerializedAs("ballManager")] [SerializeField] private BallGoalManager ballGoalManager;
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
        
        // Get if ball has rigidbody and is not kinematic (not stopped already)
        bool hasRigidBodyAndNotKinematic = other.TryGetComponent(out Rigidbody theRigidbody) && !theRigidbody.isKinematic;

        if (!hasRigidBodyAndNotKinematic)
            return;

        scoreManager.ScoreGoal(team);
        ballGoalManager.ScoreGoal(team);
    }
}