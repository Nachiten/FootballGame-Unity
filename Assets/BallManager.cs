using UnityEngine;

public class BallManager : MonoBehaviour
{
    // private Rigidbody rb;
    //
    // private void Awake()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }
    //
    // public void ScoreGoal(int team)
    // {
    //     // Disable this rigidbody
    //     SetRigidbodyEnabled(false);
    //     
    //     Invoke(nameof(ResetBall), 5f);
    // }
    //
    // private void ResetBall()
    // {
    //     // Reset the ball's position
    //     transform.position = Vector3.zero;
    //     
    //     // Enable this rigidbody
    //     SetRigidbodyEnabled(true);
    // }
    //
    // private void SetRigidbodyEnabled(bool rigidbodyEnabled)
    // {
    //     rb.isKinematic = !rigidbodyEnabled;
    // }
}
