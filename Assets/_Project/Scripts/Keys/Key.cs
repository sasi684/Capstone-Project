using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private SO_Key _key;

    public void Interact()
    {
        GameState.Instance.CollectKey(_key);
        Destroy(gameObject);
    }

}
