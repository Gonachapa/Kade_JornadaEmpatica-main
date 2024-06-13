using UnityEngine;

public class CanvasActivator : MonoBehaviour
{
    // Referência para o canvas que você deseja controlar
    public GameObject canvas;
    public GameObject[] objectsToActivate;
    public GameObject[] objectsToActivate2;

    void Update()
    {
        // Verifica se a tecla "Z" foi pressionada
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // Inverte a visibilidade do canvas
            canvas.SetActive(!canvas.activeSelf);

            // Percorre todos os objetos no array e inverte a visibilidade de cada um
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(!obj.activeSelf);
            }
            foreach (GameObject obj1 in objectsToActivate2)
            {
                obj1.SetActive(true);
            }
        }
    }
}
