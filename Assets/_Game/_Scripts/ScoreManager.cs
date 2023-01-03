using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private ScoreManagerUI scoreManagerUI;
    
    private int teamLeftScore;
    private int teamRightScore;

    // Start is called before the first frame update
    void Awake()
    {
        scoreManagerUI.UpdateGoals(teamLeftScore, teamRightScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
