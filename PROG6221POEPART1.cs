using System;

class Ingredient {
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
}

class Step {
    public string Description { get; set; }
}

class Recipe {
    private Ingredient[] ingredients;
    private Step[] steps;

    public void AddIngredients() {
        Console.WriteLine("Enter the number of ingredients:");
        int numIngredients = int.Parse(Console.ReadLine());

        ingredients = new Ingredient[numIngredients];

        for (int i = 0; i < numIngredients; i++) {
            Console.WriteLine($"Enter details for ingredient {i + 1}:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Quantity: ");
            double quantity = double.Parse(Console.ReadLine());
            Console.Write("Unit: ");
            string unit = Console.ReadLine();
            ingredients[i] = new Ingredient {
                Name = name,
                Quantity = quantity,
                Unit = unit
            };
        }
    }

    public void AddSteps() {
        Console.WriteLine("Enter the number of steps:");
        int numSteps = int.Parse(Console.ReadLine());

        steps = new Step[numSteps];

        for (int i = 0; i < numSteps; i++) {
            Console.WriteLine($"Enter details for step {i + 1}:");
            Console.Write("Description: ");
            string description = Console.ReadLine();

            steps[i] = new Step {
                Description = description
            };
        }
    }

    public void DisplayRecipe() {
        Console.WriteLine("Recipe:");

        // Display ingredients
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in ingredients) {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        // Display steps
        Console.WriteLine("Steps:");
        for (int i = 0; i < steps.Length; i++) {
            Console.WriteLine($"{i + 1}. {steps[i].Description}");
        }
    }

    public void ScaleRecipe(double factor) {
        foreach (var ingredient in ingredients) {
            ingredient.Quantity *= factor;
        }
        Console.WriteLine("Recipe scaled successfully.");
    }

    public void ResetQuantities() {
        // Implement reset quantities logic here
    }

    public void ClearData() {
        ingredients = null;
        steps = null;
        Console.WriteLine("All data cleared. Enter a new recipe.");
    }
}

class Program {
    static void Main(string[] args) {
        Recipe recipe = new Recipe();

        // Prompt user to enter details for a recipe
        Console.WriteLine("Enter the details for the recipe:");
        recipe.AddIngredients();
        recipe.AddSteps();

        // Display the recipe
        recipe.DisplayRecipe();

        // Allow user to scale the recipe
        Console.WriteLine("Enter a scaling factor (0.5, 2, or 3):");
        double factor = double.Parse(Console.ReadLine());
        recipe.ScaleRecipe(factor);

        // Display the scaled recipe
        recipe.DisplayRecipe();

        // Allow user to reset quantities
        Console.WriteLine("Do you want to reset quantities to original values? (yes/no)");
        string resetChoice = Console.ReadLine();
        if (resetChoice.ToLower() == "yes") {
            recipe.ResetQuantities();
            recipe.DisplayRecipe();
        }

        // Allow user to clear data
        Console.WriteLine("Do you want to clear all data? (yes/no)");
        string clearChoice = Console.ReadLine();
        if (clearChoice.ToLower() == "yes") {
            recipe.ClearData();
        }
    }
}