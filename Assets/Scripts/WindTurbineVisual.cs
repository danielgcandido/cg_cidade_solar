using UnityEngine;

public class WindTurbineVisual : MonoBehaviour
{
    [Header("Pivot do rotor (objeto com as pás como filhos)")]
    public Transform rotorPivot;

    public float rotationSpeed = 180f; // graus por segundo

    void Update()
    {
        if (rotorPivot != null)
        {
            rotorPivot.Rotate(0f, 0f, rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}
