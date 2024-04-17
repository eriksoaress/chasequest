using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class VerifyWin : MonoBehaviour
{


    // fazer referência ao dicionario de animais

// criar um dicionario com o nome de todos os tipos de animais, se ele etiver com tudo true  leve o player para a tela incial

    public Dictionary<string, bool> animals = new Dictionary<string, bool>();

    private void Awake()
    {
        animals.Add("snake",false);
        animals.Add("sheep",false);
        animals.Add("SnakeDesert",false);
        animals.Add("RatoDesert",false);
        animals.Add("coiote",false);
        animals.Add("UrsoPardo",false);
        animals.Add("CobraTaiga",false);
        animals.Add("prea",false);
        animals.Add("loboguara",false);
        animals.Add("UrsoNegro",false);
        animals.Add("LoboTundra",false);
        animals.Add("CobraGelida",false);
    }

    public void Verify()
    {
        bool win = true;
        foreach (var animal in animals)
        {
            if (!animal.Value)
            {
                win = false;
                Debug.Log("Você ainda não pegou todos os animais, falta o " + animal.Key);

                break;
            }
        }

        if (win)
        {
            SceneManager.LoadScene("GameWon");
            Debug.Log("Você ganhou");
        }
    }

    public void SetAnimal(string animal)

    {

        // tratar a string para que ela fique igual ao nome do animal no dicionario
        // exemplo snake e snake(1) são a mesma coisa

        if (animal.Contains("("))
        {
            animal = animal.Substring(0, animal.IndexOf("("));
            //tirar o espaço em branco
            animal = animal.Trim();

        }


        // log no console para verificar se o animal foi setado corretamente
        Debug.Log(animals[animal]);
        Debug.Log(animal + " setado como true");
        animals[animal] = true;
        Debug.Log(animals[animal]);

        //invocar o metodo verify

        Verify();

    }


}
