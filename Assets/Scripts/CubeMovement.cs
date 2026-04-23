using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] float rollSpeed = 3f;
    private bool isMoving;

    void Update()
    {
        if (isMoving) return;

        var keyboard = Keyboard.current;

        if (keyboard.wKey.isPressed) Assemble(Vector3.forward);
        else if (keyboard.sKey.isPressed) Assemble(Vector3.back);
        else if (keyboard.aKey.isPressed) Assemble(Vector3.left);
        else if (keyboard.dKey.isPressed) Assemble(Vector3.right);

        void Assemble(Vector3 dir)
        {
            var pivotPoint = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(pivotPoint, axis));
        }
    }

    IEnumerator Roll(Vector3 pivotPoint, Vector3 axis)
    {
        isMoving = true;

        for (int i = 0; i < (90 / rollSpeed); i++)
        {
            transform.RotateAround(pivotPoint, axis, rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }

        isMoving = false;
    }
}