using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    public Transform jogador;
    public float distanciaMinima = 2.0f; // Distância mínima entre o cão e o jogador
    public float velocidade = 3.0f;

    void Update()
    {
        Vector3 direcao = jogador.position - transform.position;
        if (direcao.magnitude > distanciaMinima)
        {
            // Move o cão em direção ao jogador
            transform.position = Vector3.MoveTowards(transform.position, jogador.position, velocidade * Time.deltaTime);
        }
    }
}
