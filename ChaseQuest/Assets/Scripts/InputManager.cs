using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public AnimalBook animalBook;

    public SoundEffectsPlayer soundPlayer;

    // Update is called once per frame
    void Update()
    {
        // Verifica se a tecla Q foi pressionada
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Chama o método ToggleAnimalBook() do script AnimalBook
            animalBook.ToggleAnimalBook();
            soundPlayer.PlayOpenBookSFX();
        }
        
    }
}
