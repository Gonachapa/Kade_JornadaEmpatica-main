using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Importa o SceneManager

public class HealthBar : MonoBehaviour
{
    // Referência para a imagem da barra de vida
    public Image healthBarImage;

    // Vida máxima do jogador
    private float maxHealth = 100f;

    // Vida atual do jogador
    private float currentHealth;

    // Lista de botões
    public List<Button> buttons;

    // Nome da cena para trocar
    public string NomeDaCena;

    void Start()
    {
        // Inicializa a vida atual com a vida máxima
        currentHealth = maxHealth;
        UpdateHealthBar();

        // Adiciona eventos de clique aos botões
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClicked(button));
        }
    }

    // Método para reduzir a vida
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();

        // Verifica se a vida é igual a 0 e troca de cena
        if (currentHealth == 0)
        {
            SceneManager.LoadScene(NomeDaCena);
        }
    }

    // Método para curar
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    // Atualiza a barra de vida
    private void UpdateHealthBar()
    {
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }

    // Método chamado ao clicar em um botão
    private void OnButtonClicked(Button clickedButton)
    {
        // Reduz a vida em 20 ao clicar em um botão
        TakeDamage(20f);
    }
}