using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float XAxisSpeed = 5;
    public float ZAxisSpeed = 5;

    public PlayerCharacter PlayerData;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsMovementPressed())
        {
            int directionX = GetDirection(Input.GetAxisRaw("Horizontal")),
                directionZ = GetDirection(Input.GetAxisRaw("Vertical"));
            Move(XAxisSpeed * Time.deltaTime * directionX, ZAxisSpeed * Time.deltaTime * directionZ);
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
