using System;
using Unity.Netcode;
using UnityEngine;

public class BallNetwork : NetworkBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void OnNetworkSpawn()
    {
        GetBallPositionServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    private void GetBallPositionServerRpc()
    {
        SetBallPositionClientRpc(transform.position);
    }

    [ClientRpc]
    private void SetBallPositionClientRpc(Vector3 pos)
    {
        transform.position = pos;
    }

    [ServerRpc(RequireOwnership = false)]
    private void ApplyForceServerRpc(Vector3 force)
    {
        rb.AddForce(force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ApplyForceServerRpc(-collision.impulse - collision.relativeVelocity);
    }
}
