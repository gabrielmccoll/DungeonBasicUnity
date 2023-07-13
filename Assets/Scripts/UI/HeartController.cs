using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    public int maxHearts = 3; // Maximum number of hearts
    public Image heartPrefab; // Prefab of the heart image
    public Transform heartContainer; // Container for the heart images
    public Sprite fullHeart; // Full heart sprite
    public Sprite emptyHeart; // Empty heart sprite

    private int currentHearts; // Current number of hearts


    [SerializeField] SceneController _sceneController;
    [SerializeField] PlayerMove _playerMove;
    float countDown;
    SpriteRenderer sr;
    private Color originalColor;
    private bool isDamaged = false;




    private void Start()
    {
        sr = _playerMove.GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        currentHearts = maxHearts;
        CreateHearts();

      
    }



    private void Update()
    {
        if (isDamaged)
        {
            StartCoroutine(FlashRed());
            isDamaged = false;
        }
        //bit of testing for a health power up 
        if (Input.GetKeyDown(KeyCode.I))
        {
         
            MaxHeartsIncrease();
        }
    }



    private void CreateHearts()
    {
        // Instantiate heart images based on maxHearts
        for (int i = 0; i < maxHearts; i++)
        {
            Image heartImage = Instantiate(heartPrefab, heartContainer);
            heartImage.sprite = fullHeart;
        }
    }



    private void MaxHeartsIncrease()
    {

        if (currentHearts < maxHearts)
        {
            maxHearts++;
            Image heartImage = Instantiate(heartPrefab, heartContainer);
            heartImage.sprite = fullHeart;
            heartContainer.GetChild(currentHearts).GetComponent<Image>().sprite = fullHeart;
            heartImage.transform.SetAsFirstSibling();
            currentHearts = maxHearts;
            FillHearts();
        }

    }

    public void TakeDamage()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            heartContainer.GetChild(currentHearts).GetComponent<Image>().sprite = emptyHeart;
            isDamaged = true;
            Debug.Log(" TakeDamage()");

            if (currentHearts == 0)

            {
                _sceneController.GameOver();
            }
        }
    }



    private System.Collections.IEnumerator FlashRed()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.7f);
        sr.color = originalColor;
    }


    public void AddHeart()
    {
        if (currentHearts < maxHearts)
        {
            heartContainer.GetChild(currentHearts).GetComponent<Image>().sprite = fullHeart;
            currentHearts++;
        }

    }

    private void FillHearts()
    {
        foreach (Transform child in heartContainer)
        {
            child.GetComponent<Image>().sprite = fullHeart;
        }
       
    }

    private void ResetHearts()
    {
        foreach (Transform child in heartContainer)
        {
            Destroy(child.gameObject);
        }
        currentHearts = maxHearts;
    }
}



