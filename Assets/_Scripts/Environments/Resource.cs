using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ItemData itemToGive;
    public int quantityPerHit = 1;
    public int capacity;

    public void Gather(Vector3 hitPoint, Vector3 hitNormal)
    {
        for (int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0) { break; }
            capacity -= 1;
            Instantiate(itemToGive.dropPrefab, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }

        if (capacity <= 0)
            Destroy(gameObject);
    }

    public void Fishing(Vector3 hitPoint)
    {
        for (int i = 0; i < quantityPerHit; i++)
        {
            if (capacity <= 0) { break; }
            capacity -= 1;
            GameObject fish = Instantiate(itemToGive.dropPrefab, hitPoint, Quaternion.LookRotation(PlayerController.instance.transform.position, Vector3.up));
            fish.GetComponent<Rigidbody>().AddForce(((PlayerController.instance.transform.position - fish.transform.position).normalized+Vector3.up)* 300);
        }

    }
}