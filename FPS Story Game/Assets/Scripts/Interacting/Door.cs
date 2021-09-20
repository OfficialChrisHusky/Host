using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

    [SerializeField] private Animator animator;
    [SerializeField] private bool canPlayerOpen;
    [SerializeField] private bool isOpen;

    public bool canInteract = true;

    private void Start() {

        animator.SetBool("Open", false);
        animator.SetBool("Close", false);

    }

    public override void Interact() {
        
        if(canInteract && canPlayerOpen) {

            StartCoroutine(Open());

        }

    }

    public IEnumerator Open() {

        canInteract = false;

        if(isOpen) {

            animator.SetBool("Open", false);
            animator.SetBool("Close", true);

        } else {

            animator.SetBool("Open", true);
            animator.SetBool("Close", false);

        }

        yield return new WaitForSeconds(5);

        isOpen = !isOpen;
        canInteract = true;

        yield return null;

    }

}
