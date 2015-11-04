using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float xAxisSpeed = 5;
    public float zAxisSpeed = 5;

    public bool isLeader;
    public bool doPartySwap = false;
    public GameManager gameManager;
    public PlayerCharacter playerData;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isLeader || !playerData.playerParty.isActive)
        {
            return;
        }
        if (IsMovementPressed())
        {
            int directionX = GetDirection(Input.GetAxisRaw("Horizontal")),
                directionZ = GetDirection(Input.GetAxisRaw("Vertical"));
            Move(xAxisSpeed * Time.deltaTime * directionX, zAxisSpeed * Time.deltaTime * directionZ);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            doPartySwap = true;
        }
    }

    void LateUpdate()
    {
        if (doPartySwap && isLeader && playerData.playerParty.isActive)
        {
            if (gameManager != null)
            {
                gameManager.SwapParties();
            }
            doPartySwap = false;
        }
    }

    bool IsMovementPressed()
    {
        return Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0;
    }

    int GetDirection(float axisVal)
    {
        if (axisVal < 0)
        {
            return -1;
        }
        else if (axisVal > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    void Move(float dX, float dZ)
    {
        Vector3 newPos = transform.position;
        newPos.x += dX;
        newPos.z += dZ;
        transform.position = newPos;
    }
}
