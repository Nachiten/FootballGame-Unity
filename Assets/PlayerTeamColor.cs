using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerTeamColor : NetworkBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    
    private NetworkVariable<int> team = new();
    
    // 0 = Left = Blue
    // 1 = Right = Red
    private readonly List<Color> colors = new()
    {
        Color.blue,
        Color.red,
    };
    
    private void Awake()
    {
        // Subscribing to a change event. This is how the owner will change its color.
        // Could also be used for future color changes
        team.OnValueChanged += OnValueChanged;
    }

    public override void OnNetworkSpawn()
    {
        SetColor();
    }
    
    public override void OnDestroy()
    {
        // Unsubscribing from the event
        team.OnValueChanged -= OnValueChanged;
    }
    
    private void OnValueChanged(int prev, int next)
    {
        _renderer.material.color = GetColor(next);
    }
    
    public void ChooseTeam(int newTeam)
    {
        CommitNetworkColorServerRpc(newTeam);
    }

    [ServerRpc]
    private void CommitNetworkColorServerRpc(int newTeam)
    {
        team.Value = newTeam;
    }
    
    private void SetColor()
    {
        _renderer.material.color = GetColor(team.Value);
    }

    private Color GetColor(int theTeam)
    {
        return theTeam == 0 ? colors[0] : colors[1];
    }
}
