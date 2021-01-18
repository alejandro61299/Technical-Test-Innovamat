using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Translation")]
public class NumbersTranslation : ScriptableObject
{

    [System.Serializable]
    public struct NumberTranslation
    {
        public int number;
        public string catalan;
        public string spanish;
        public string english;
    }

    [SerializeField]
    public List<NumberTranslation> numbers;

    public void GetNumberName(int number, Language language, out string name)
    {
        name = "unknown";

        foreach (NumberTranslation numTranslation in numbers)
        {
            if (numTranslation.number == number)
            {
                switch (language)
                {
                    case Language.Catalan:
                        name = numTranslation.catalan;
                        break;
                    case Language.Spanish:
                        name = numTranslation.spanish;
                        break;
                    case Language.English:
                        name = numTranslation.english;
                        break;
                    default:
                        break;
                }
            }
        }
    }


}
