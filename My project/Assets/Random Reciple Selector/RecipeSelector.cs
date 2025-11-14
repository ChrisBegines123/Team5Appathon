using UnityEngine;
using TMPro;

public class RecipeSelector : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI recipeText;  
    [Header("Recipes")]
    [TextArea(2, 8)]
    public string[] recipes;

    void Start()
    {
        ShowRandomRecipe();
    }

    public void ShowRandomRecipe()
    {
        if (recipes == null || recipes.Length == 0)
        {
            recipeText.text = "No recipes set!";
            return;
        }

        int index = Random.Range(0, recipes.Length);
        recipeText.text = recipes[index];
    }
}