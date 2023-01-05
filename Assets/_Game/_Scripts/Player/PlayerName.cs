using System;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerName : NetworkBehaviour
{
    [SerializeField] private TMP_Text playerNameText;
    
    private readonly NetworkVariable<FixedString32Bytes> playerName = new("", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    private void Awake()
    {
        playerName.OnValueChanged += OnPlayerNameChanged;
    }

    private void OnPlayerNameChanged(FixedString32Bytes prevValue, FixedString32Bytes newValue)
    {
        UpdatePlayerNameText();
    }

    public override void OnNetworkSpawn()
    {
        UpdatePlayerNameText();
    }

    public void SetPlayerName(string newName)
    {
        playerName.Value = newName;
        UpdatePlayerNameText();
    }
    
    private void UpdatePlayerNameText()
    {
        playerNameText.text = playerName.Value.ToString();
    }
}
