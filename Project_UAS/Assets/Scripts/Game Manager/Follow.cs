using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    private void Start()
    {
        // Mendapatkan offset antara target dan camera
        offset = transform.position - target.position;
    }
    
    private void LateUpdate()
    {
        // Mendapatkan posisi untuk camera
        Vector3 targetCamPos = target.position + offset;
        // Set posisi camera tanpa smoothing
        transform.position = targetCamPos;
    }
}