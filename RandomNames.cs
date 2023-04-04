using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class RandomNames : MonoBehaviour
{
    // Minimum age of generated names
    public int minAge = 18;

    // Maximum age of generated names
    public int maxAge = 60;

    // Number of names to generate
    public int numOfNames = 100;

    // Set to store generated names and ensure uniqueness
    private HashSet<string> generatedNames = new HashSet<string>();

    // Lists of male and female first names, and last names
    private readonly List<string> maleFirstNames = new List<string>()
    {
        // Male first names
    };

    private readonly List<string> femaleFirstNames = new List<string>()
    {
        // Female first names
    };

    private readonly List<string> lastNames = new List<string>()
    {
        // Last names
    };
    
    private void Awake()
    {
        // Store a reference to the singleton instance of this class
        instance = this;
    }

    private void Start()
    {
        // Generate the specified number of names
        GenerateCards(numOfNames);
    }

    private void GenerateNames(int numOfNames)
    {
        for (int i = 0; i < numOfNames; i++)
        {
            // Randomly determine gender
            bool gender = Random.Range(0, 2) == 0;

            // Get a random first name based on gender
            string firstName = GetName(isMale);

            // Get a random last name
            string lastName = lastNames[Random.Range(0, lastNames.Count)];

            // Generate a fake ID
            string id = GenerateFakeID();

            // Concatenate first and last names
            string fullName = firstName + " " + lastName;

            // Ensure the name is unique
            while (generatedNames.Contains(fullName))
            {
                // Generate a new first name based on gender
                firstName = GetName(isMale);

                // Generate a new last name
                lastName = lastNames[Random.Range(0, lastNames.Count)];

                // Concatenate the new first and last names
                fullName = firstName + " " + lastName;
            }

            // Add the unique name to the set of generated names
            generatedNames.Add(fullName);
        }
    }

    private string GetName(bool gender)
    {
        // Choose the appropriate name list based on gender
        List<string> nameList = gender ? maleFirstNames : femaleFirstNames;

        // Return a random name from the chosen list
        return nameList[Random.Range(0, nameList.Count)];
    }
}
