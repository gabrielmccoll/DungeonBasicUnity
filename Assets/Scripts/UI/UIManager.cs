using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public PlayerHealth playerHealth;
    public GameObject heartPrefab; // Prefab of the heart UI element
    public Image heart; // Image of the heart UI element
    public Transform heartContainer; // Container for the heart UI elements
    public Sprite fullHeartSprite; // Full heart sprite
    public Sprite emptyHeartSprite; // Empty heart sprite

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void CreateHearts(int maxhearts, int fullhearts)
    {

        int emptyhearts = (maxhearts - fullhearts);

        // Instantiate heart images
        for (int i = 0; i < fullhearts; i++)
        {
            Image heartImage = Instantiate(heart, heartContainer);
            heartImage.sprite = fullHeartSprite;
        }


        for (int i = 0; i < emptyhearts; i++)
        {
            Image heartImage = Instantiate(heart, heartContainer);
            heartImage.sprite = emptyHeartSprite;
        }

    }


    public void MaxHeartsIncrease()
    {

        //increase max hearts variable
        playerHealth.maxHearts++;
        //generate a new heart image on UI
        GameObject heartObject = Instantiate(heartPrefab, heartContainer);
        Image heartImage = heartObject.GetComponent<Image>();
        if (heartImage != null)
        {
            heartImage.sprite = fullHeartSprite;
        }
        //set the current hearts variable to full and then replace the images with full hearts
        playerHealth.currentHearts = playerHealth.maxHearts;
        FillHearts();
    }

    public void FillHearts()
    {
        foreach (Transform child in heartContainer)
        {
            child.GetComponent<Image>().sprite = fullHeartSprite;
        }

    }

    public void UnfillHeart()
    {

            playerHealth.currentHearts--;
            Image heartImage = heartContainer.GetChild(playerHealth.currentHearts).GetComponent<Image>();
            if (heartImage != null)
            {
                heartImage.sprite = emptyHeartSprite;
            }
        
 
    }

    //public void UpdateHeartsUI(int currentHearts)
    //{
    //    Debug.Log(currentHearts);
    //    foreach (Transform child in heartContainer)
    //    {
    //        Destroy(child.gameObject);
    //    }

    //    for (int i = 0; i < currentHearts; i++)
    //    {
    //        GameObject heartObject = Instantiate(heartPrefab, heartContainer);
    //        Image heartImage = heartObject.GetComponent<Image>();
    //        if (heartImage != null)
    //        {
    //            heartImage.sprite = fullHeartSprite;
    //        }
    //    }
    //}


    public void ResetHearts()
    {
        foreach (Transform child in heartContainer)
        {
            Destroy(child.gameObject);
        }
        playerHealth.currentHearts = playerHealth.maxHearts;
    }
}
