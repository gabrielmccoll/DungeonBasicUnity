using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    public int maxHearts = 3; // Maximum number of hearts
    public Image[] heartImages; // Array of heart images
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
        Debug.Log("HeartController Start");
    }

    private void Update()
    {
        if (isDamaged)
        {
            StartCoroutine(FlashRed());
            isDamaged = false;
        }
    }

    public void TakeDamage()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            heartImages[currentHearts].sprite = emptyHeart;
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
}
