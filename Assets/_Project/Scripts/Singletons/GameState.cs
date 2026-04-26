using UnityEngine;

public class GameState : GenericSingleton<GameState>
{
    private bool _hasUpperFloorBathroomKey;
    private bool _hasMainEntranceKey;
    private bool _hasFirstRoomKey;

    public void CollectKey(SO_Key key)
    {
        switch (key.KeyName)
        {
            case "Upper Floor Bathroom Key":
                _hasUpperFloorBathroomKey = true;
                break;
            case "Main Entrance Key":
                _hasMainEntranceKey = true;
                break;
            case "First Room Key":
                _hasFirstRoomKey = true;
                break;
            default:
                Debug.LogWarning("Unknown key picked up.");
                break;
        }
    }

    public bool UnlockDoor(SO_Door door)
    {
        switch (door.DoorName)
        {
            case "Upper Floor Bathroom Door":
                return _hasUpperFloorBathroomKey;
            case "Main Entrance Door":
                return _hasMainEntranceKey;
            case "First Room Door":
                return _hasFirstRoomKey;
            default:
                Debug.LogWarning("Unknown door.");
                return false;
        }
    }
}
