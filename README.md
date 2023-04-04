# RandomNames
RandomNames is a Unity script that generates a set of random names based on the provided lists of first names and last names. The script ensures that each generated name is unique by storing the generated names in a hash set and checking for duplicates.

## Usage
To use the RandomNames script in your Unity project, simply attach it to an empty game object in your scene. You can then specify the minimum age, maximum age, and number of names to generate in the script's public variables in the Unity editor.

The script uses lists of male and female first names, as well as a list of last names, to generate the names. You can modify these lists in the script to include your own names.

### Example
Here's an example of how to use the RandomNames script:

```
using UnityEngine;

public class Example : MonoBehaviour
{
    public RandomNames randomNames;

    private void Start()
    {
        randomNames.numOfNames = 10;
        randomNames.GenerateNames(randomNames.numOfNames);

        foreach (string name in randomNames.generatedNames)
        {
            Debug.Log(name);
        }
    }
}
```

In this example, we have an instance of the RandomNames script attached to a game object in the scene. We set the numOfNames variable to 10 and then generate the names using the GenerateNames method. We then loop through the generated names and log them to the Unity console.

## License
This script is released under the MIT License. Feel free to use it in your own projects and modify it as needed.
