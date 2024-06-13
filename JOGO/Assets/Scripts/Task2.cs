using UnityEngine;

public class Task2 : MonoBehaviour
{
    public GameObject objectI;
    public float interactionDistance = 2.0f;
    public bool useAlternateMessage = false;

    void Update()
    {
        CheckProximityAndInteract();
    }

    void CheckProximityAndInteract()
    {
        if (objectI == null)
        {
            Debug.LogWarning("objectI não está atribuído.");
            return;
        }

        float distanceToObjectI = Vector3.Distance(transform.position, objectI.transform.position);
        
        if (distanceToObjectI <= interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                useAlternateMessage = true;
                Debug.Log("useAlternateMessage agora é: " + useAlternateMessage);
            }
        }
    }
}
