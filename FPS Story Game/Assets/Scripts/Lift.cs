using UnityEngine;

public class Lift : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float end;

    [SerializeField] private bool moveOnAwake;

    private Rigidbody rb;
    private bool isMoving;

    private void Awake() {

        rb = GetComponent<Rigidbody>();

        if(moveOnAwake) {

            isMoving = true;

        }

    }

    private void Update() {

        if(isMoving) {

            Move();

        }
        
    }

    public void StartMoving() {

        isMoving = true;

    }

    private void Move() {

        if(transform.position.y < end) {

            transform.position += new Vector3(0, speed * Time.deltaTime, 0);

        } else {

            isMoving = false;

        }

    }

}