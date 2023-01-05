using TMPro;
using Unity.Netcode;
using Unity.Tutorials.Core.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameSubmitUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(SubmitName);
    }

    private void SubmitName()
    {
        string submittedText = inputField.text;

        if (submittedText.IsNullOrEmpty())
            return;
        
        NetworkManager.Singleton.LocalClient.PlayerObject.GetComponentInChildren<PlayerName>().SetPlayerName(submittedText);
    }
}
