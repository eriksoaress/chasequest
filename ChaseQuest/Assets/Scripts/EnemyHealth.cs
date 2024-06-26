using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Vida máxima do inimigo
    public int currentHealth; // Vida atual do inimigo
    private bool damaged; // Indica se o inimigo já foi danificado

    private float damageCooldown = 0.25f; // Tempo de recarga para permitir novo dano
    private float cooldownTimer; 
    public GameObject player;// Temporizador para controlar o tempo de recarga

    //pegar o togle do check do livro
    public GameObject checkImage;

    public VerifyWin verifyWin;

    private Knockback knockback; // Referência ao componente Knockback

    private Dictionary<string, int> animalHeal = new Dictionary<string, int>();

    private void Awake(){
        knockback = GetComponent<Knockback>();
        animalHeal.Add("snake",3);
        animalHeal.Add("sheep",2);
        animalHeal.Add("SnakeDesert",4);
        animalHeal.Add("RatoDesert",2);
        animalHeal.Add("coiote",6);
        animalHeal.Add("UrsoPardo",8);
        animalHeal.Add("CobraTaiga",4);
        animalHeal.Add("prea",2);
        animalHeal.Add("loboguara",6);
        animalHeal.Add("UrsoNegro",10);
        animalHeal.Add("LoboTundra",6);
        animalHeal.Add("CobraGelida",5);
    }
    private void Start()
    {
        currentHealth = maxHealth; // Configura a vida atual para a vida máxima no início
        cooldownTimer = damageCooldown; // Configura o temporizador para o tempo de recarga inicial
    }

    private void Update()
    {
        // Atualiza o temporizador de recarga
        if (damaged)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                damaged = false;
                cooldownTimer = damageCooldown; // Reinicia o temporizador
            }
        }
    }


    // Método para reduzir a vida do inimigo
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduz a vida atual pelo valor do dano
        if (gameObject.name.StartsWith("coiote") || gameObject.name.StartsWith("LoboTundra"))
        {
            knockback.GetKnockedBack(PlayerController.instance.transform, 15f);
        }
        else
        {
            knockback.GetKnockedBack(PlayerController.instance.transform, 10f);
        }
        damaged = true; // Aplica o knockback no inimigo
        // Verifica se a vida atual é menor ou igual a zero, indicando que o inimigo foi derrotado
        StartCoroutine(FlashRed());
        if (currentHealth <= 0)
        {
            Die(); // Chama o método de morte do inimigo
        }
    }

    private IEnumerator FlashRed()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Método chamado quando o inimigo é derrotado
    private void Die()
    {   
        // Adiciona a vida do inimigo ao jogador
        foreach (var animal in animalHeal)
        {
            if (gameObject.name.StartsWith(animal.Key))
            {
                player.GetComponent<PlayerHealth>().Heal(animal.Value);
                break; // Saia do loop após encontrar o animal correspondente
            }
        }
        // Aqui você pode adicionar qualquer lógica que desejar para quando o inimigo for derrotado
        Debug.Log("O"+ gameObject.name +"foi derrotado!");

        // Por exemplo, você pode desativar o GameObject do inimigo quando ele morrer

        // dar o set na imagem para true 

        checkImage.SetActive(true);

        // pegar o script VerifyWin e chamar o metodo SetAnimal passando o nome do animal

        verifyWin.SetAnimal(gameObject.name);
        
        gameObject.SetActive(false);
    }
}
