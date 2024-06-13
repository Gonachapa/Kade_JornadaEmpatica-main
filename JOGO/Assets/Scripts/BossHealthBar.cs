using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealthBar : MonoBehaviour
{
    // Referência para a imagem da barra de vida
    public Image healthBarImage;

    // Vida máxima do jogador
    private float maxHealth = 100f;

    // Vida atual do jogador
    private float currentHealth;

    // Lista de botões
    public List<Button> buttons;

    // Lista de objetos que serão ativados quando a vida for menor ou igual a 20
    public List<GameObject> objectsToActivate;

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

        // Ativa ou desativa objetos com base na vida atual
        foreach (GameObject obj in objectsToActivate)
        {
            if (currentHealth <= 20f)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }

    // Método chamado ao clicar em um botão
    private void OnButtonClicked(Button clickedButton)
    {
        // Reduz a vida em 40 ao clicar em um botão
        TakeDamage(40f);
    }
}