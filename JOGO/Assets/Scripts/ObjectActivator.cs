using UnityEngine;
using System.Collections.Generic;

public class ObjectActivator : MonoBehaviour
{
    public List<GameObject> objectsToToggle; // Lista de objetos a serem alternados

    public void OnActivate()
    {
        ToggleActiveState();
    }
    private void ToggleActiveState()
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(!obj.activeSelf); // Alterna o estado ativo de cada objeto na lista
        }
    }
}
