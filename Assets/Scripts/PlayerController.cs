using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static bool canMove;
    bool idle;
    bool isRun;
    Inputs inputs;
    Vector2 movementVector;
    Vector3 playerMovementVector;
    public static List<IOAbstract> items = new List<IOAbstract>();

    [SerializeField] private Animator animator;

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] InventoryManager inventoryManager;
    private void Awake()
    {
        inputs = new Inputs();

        inputs.PlayerAction.Interact.started += Interact;
        inputs.PlayerAction.Reload.started += Reload;
        inputs.PlayerAction.Run.started += Run;
        inputs.PlayerAction.Run.canceled += Run;
    }
    private void Start()
    {
        canMove = true;
    }
    private void Reload(InputAction.CallbackContext context)
    {
        foreach (var item in items)
        {
            if (item is Battery)
            {
                FlashLight.timer = 120f;
                items.Remove(item);
                inventoryManager.SetInventory();
                break;
            }
        }
    }
    private void Run(InputAction.CallbackContext ctx)
    {
        isRun = ctx.ReadValueAsButton();
        animator.SetBool("isRunning", isRun);
    }
    private void Interact(InputAction.CallbackContext context)
    {
        EnvironmentDetecting();
    }
    private void EnvironmentDetecting()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,1f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out IOAbstract io))
            {
                io.NotifyInteractableObjects();
                TakeEnvironment(io);
                inventoryManager.SetInventory();
            }
        }
    }
    private void Update()
    {
        Movement();
        Rotation();
    }
    private void Movement()
    {
        if (canMove)
        {
            float running = inputs.PlayerAction.Run.IsPressed() ? 2 : 1;
            movementVector = inputs.PlayerAction.Movement.ReadValue<Vector2>();
            idle = Mathf.Abs(movementVector.magnitude) > 0 ? true : false;
            animator.SetBool("isWalking", idle);
            playerMovementVector = new Vector3(movementVector.x, 0, movementVector.y);
            transform.position += playerMovementVector * speed * Time.deltaTime * running;
        }
    }
    private void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (playerMovementVector != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(playerMovementVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 180 * Time.deltaTime * rotationSpeed);
        }
    }
    private void TakeEnvironment(IOAbstract item)
    {
        if(items.Count < 6 && !items.Contains(item))
        {
            items.Add(item);
            Debug.Log(items.Count);
        }
    }
    private void OnEnable()
    {
        inputs.Enable();
    }
    private void OnDisable()
    {
        inputs.Disable();
    }
}
