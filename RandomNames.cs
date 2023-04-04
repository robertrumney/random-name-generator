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
        "Kwame", "Sekou", "Kofi", "Olu", "Chidi", "Tunde", "Kwasi", "Abdul", "Kwaku", "Kwadwo",
        "Emeka", "Obi", "Jelani", "Ade", "Adisa", "Akintunde", "Ayo", "Babatunde", "Chike", "Eze",
        "Idris", "Kamau", "Lekan", "Mandla", "Mawuli", "Nnamdi", "Oluwafemi", "Oluwatobi", "Sekani", "Sizwe",
        "Liam", "Noah", "William", "James", "Oliver", "Benjamin", "Elijah", "Lucas", "Mason",
        "Alexander", "Ethan", "Jacob", "Michael", "Henry", "Jackson", "Sebastian", "Aiden",
        "Matthew", "Samuel", "David", "Joseph", "Carter", "Owen", "Wyatt", "Jayden",
        "Gabriel", "Dylan", "Isaac", "Anthony", "Nathan", "Leo", "Lincoln", "Eli", "Andrew",
        "Joshua", "Ryan", "Nicholas", "Christopher", "Asher", "Colton", "Max", "Hunter", "Thomas",
        "Adam", "Julian", "Dominic", "Austin", "Caleb", "Ezra", "Grayson", "Cameron", "Robert",
        "Brandon", "Landon", "Connor", "Brayden", "Carson", "Brody", "Jordan", "Tristan", "Antonio",
        "Easton", "Jaxon", "Cooper", "Kevin", "Josiah", "Harrison", "Xavier", "Levi", "Damian", "Chase",
        "Parker", "Ian", "Mateo", "Blake", "Jeremiah", "Gavin", "Oliver", "Luis", "Leonardo", "José",
        "Ryder", "Jason", "Tyler", "Cole", "Justin", "Finn", "Alex", "Nolan", "Silas",
        "Miles", "Juan", "Avery", "Brantley"
    };

    private readonly List<string> femaleFirstNames = new List<string>()
    {
        "Aisha", "Fatima", "Zahara", "Nia", "Sade", "Akosua", "Safiya", "Zuri", "Nala", "Amara",
        "Emma", "Olivia", "Ava", "Isabella", "Sophia", "Mia", "Charlotte", "Amelia", "Evelyn", "Abigail",
        "Harper", "Emily", "Elizabeth", "Avery", "Sofia", "Ella", "Madison", "Scarlett", "Victoria", "Aria",
        "Grace", "Chloe", "Camila", "Penelope", "Riley", "Layla", "Zoe", "Nora", "Lily", "Eleanor",
        "Hannah", "Lillian", "Addison", "Aubrey", "Ellie", "Stella", "Natalie", "Audrey", "Leah", "Aaliyah",
        "Alyssa", "Claire", "Violet", "Savannah", "Brooklyn", "Bella", "Skylar", "Maya", "Aurora", "Lucy",
        "Paisley", "Anna", "Ruby", "Kennedy", "Sadie", "Hailey", "Eva", "Emilia", "Autumn", "Quinn",
        "Piper", "Sophie", "Delilah", "Josephine", "Nevaeh", "Caroline", "Valentina", "Nova", "Everly", "Ariana",
        "Serenity", "Kimberly", "Elena", "Genesis", "Ariella", "Naomi", "Alice", "Eliana", "Clara",
        "Jessica", "Miranda", "Cora", "Kinsley", "Katherine", "Gabriella", "Allison", "Isla", "Vivian", "Josefina",
        "Jocelyn", "Adalyn", "Daisy", "Daniela", "Fiona", "Julia", "Melanie", "Aurora", "Valerie", "Natasha",
        "Hope", "Cecilia", "Lucia", "Liliana", "Summer", "Makayla", "Jayla", "Alondra", "Kaylee", "Nina"
    };

    private readonly List<string> lastNames = new List<string>()
    {
        "Smith", "Johnson", "Williams", "Jones", "Brown", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
        "Hernandez", "Lopez", "Gonzalez", "Perez", "Taylor", "Anderson", "Wilson", "Jackson", "Moore", "Martin",
        "Lee", "Gomez", "Allen", "King", "Wright", "Scott", "Green", "Baker", "Adams", "Nelson",
        "Carter", "Mitchell", "Perez", "Roberts", "Turner", "Phillips", "Campbell", "Parker", "Evans", "Edwards",
        "Collins", "Morris", "Morgan", "Reyes", "Ramirez", "Foster", "Griffin", "West", "Jordan", "Butler",
        "Hamilton", "Stevens", "Nichols", "Ross", "Cross", "Gordon", "Lane", "Sharp", "Bryant", "Hansen",
        "Hart", "Black", "Knight", "Cook", "Harvey", "Nash", "Castillo", "Jenkins", "Byrd", "Davidson",
        "Bryant", "Robbins", "Casey", "Shaw", "Mills", "Fox", "Galloway", "Bush", "Thornton", "Wagner",
        "Reid", "Mccoy", "Mcdaniel", "Mcbride", "David", "Brock", "Todd", "Blake", "Cooper", "Montgomery",
        "Perry", "Dixon", "Parks", "Richards", "Harper", "Willis", "Reed", "May", "Carroll", "Day",
        "Blake", "Holmes", "Gibson", "Barnes", "Dunn", "Spencer", "Fowler", "Murray", "Graves", "Harrington",
        "Ramos", "Dean", "Rose", "Mcdonald", "Austin", "Lambert", "Patterson", "Mendoza", "Sutton", "Curtis",
        "Dlamini", "Nkosi", "Mlambo", "Juma", "Moyo", "Kamau", "Chimamanda", "Nwosu", "Okafor", "Okeke",
        "Abimbola", "Ajayi", "Adeyemi", "Olawale", "Onyeka", "Eze", "Oluwaseun", "Oluwatobi", "Oluwatoyin", "Adesina",
        "Masuku", "Mhlongo", "Ngwenya", "Moyo", "Mukanya", "Nyathi", "Ncube", "Moyo", "Mkandla", "Ndlovu",
        "Sibanda", "Banda", "Phiri", "Mwamba", "Zulu", "Muleya", "Mulenga", "Njobvu", "Kapenda", "Kunene",
        "Van Wyk", "Naidoo", "Moosa", "Dube", "Buthelezi", "Mthembu", "Khumalo", "Malinga", "Maseko", "Mabena"
    };

    private void Start()
    {
        // Generate the specified number of names
        GenerateNames(numOfNames);
    }

    private void GenerateNames(int numOfNames)
    {
        for (int i = 0; i < numOfNames; i++)
        {
            // Randomly determine gender
            bool gender = Random.Range(0, 2) == 0;

            // Get a random first name based on gender
            string firstName = GetName(gender);

            // Get a random last name
            string lastName = lastNames[Random.Range(0, lastNames.Count)];

            // Concatenate first and last names
            string fullName = firstName + " " + lastName;

            // Ensure the name is unique
            while (generatedNames.Contains(fullName))
            {
                // Generate a new first name based on gender
                firstName = GetName(gender);

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
