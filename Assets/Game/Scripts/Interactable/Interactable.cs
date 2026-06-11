using UnityEngine;

public interface IInteractable
{
    public string Name { get; }
    public void Interact(PlayerCharacter character);
}

public interface IPickable
{
    public void Pickup(PlayerCharacter character);
}

