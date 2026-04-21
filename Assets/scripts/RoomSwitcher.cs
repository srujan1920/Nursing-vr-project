using UnityEngine;
using Unity.XR.CoreUtils;   // for XROrigin

public class RoomSwitcher : MonoBehaviour
{
    public XROrigin xrOrigin;
    public Transform lobbySpawn;
    public Transform hospitalSpawn;

    public void GoToHospitalRoom()
    {
        MoveToSpawn(hospitalSpawn);
    }

    public void GoToLobbyRoom()
    {
        MoveToSpawn(lobbySpawn);
    }

    private void MoveToSpawn(Transform spawnPoint)
    {
        if (spawnPoint == null || xrOrigin == null) return;

        // Move XR Origin position
        xrOrigin.MoveCameraToWorldLocation(spawnPoint.position);

        // Make the player look the same direction as the spawn point
        xrOrigin.MatchOriginUpCameraForward(spawnPoint.up, spawnPoint.forward);
    }
}

