using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBook : MonoBehaviour
{

    public GameObject animalBookImage;
    // Start is called before the first frame update
    
    public void ToggleAnimalBook()
    {
        //verificar se a tecla Q foi pressionada
       
            //verificar se o livro de animais está ativo
            if (animalBookImage.activeSelf)
            {
                //desativar o livro de animais
                animalBookImage.SetActive(false);
            }
            else
            {
                //ativar o livro de animais
                animalBookImage.SetActive(true);
            }
        
    }
   
}
