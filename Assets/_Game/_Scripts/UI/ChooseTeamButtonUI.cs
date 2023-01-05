using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ChooseTeamButtonUI : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private int team;
    
    private void Awake()
    {
        button.onClick.AddListener(ChooseTeam);
    }

    private void ChooseTeam()
    {
        NetworkManager.Singleton.LocalClient.PlayerObject.GetComponentInChildren<PlayerTeamColor>().ChooseTeam(team);
    }
}
