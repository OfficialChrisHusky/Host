using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable {

    [SerializeField] private Door door;

    public override void Interact() {

        if (door.canInteract) {

            StartCoroutine(door.Open());

        }

    }
}
