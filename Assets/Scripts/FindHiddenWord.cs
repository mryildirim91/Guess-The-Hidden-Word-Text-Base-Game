using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindHiddenWord : MonoBehaviour
{
    private string _hiddenWord;

    private int _lives = 5;
    private int _point = 0;

    [SerializeField]
    private InputField _playerGuessWord;

    private void Start()
    {
        UIManager.Instance.LivesUI("Lives: " + _lives.ToString());
        GetIsogramWords(Wordlist._wordList);
        SetTheHiddenWord();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && _playerGuessWord.text != "")
        {
            GuessTheHiddenWord();
        }
    }

    private void SetTheHiddenWord() // Rasgele Hiddenword seç ve ata.
    {
        int randomWordIndex = Random.Range(0, GetIsogramWords(Wordlist._wordList).Count);
        _hiddenWord = GetIsogramWords(Wordlist._wordList)[randomWordIndex];

        GiveHintAboutHiddenWord();

        UIManager.Instance.PointsUI("Points: " + _point.ToString());

        Debug.Log(_hiddenWord);
    }

    private void GuessTheHiddenWord() // Hiddenwordü tahmin etmeye çalış
    {
        if (_playerGuessWord.text == _hiddenWord)
        {
            Wordlist._wordList.Remove(_hiddenWord);

            UIManager.Instance.FoundTheHiddenWordUI("You have found the hidden word! Well Done!");
            _point++;
            SetTheHiddenWord();         
        }

        else if(_lives > 0)
        {
            _lives--;
            UIManager.Instance.LivesUI("Lives: " + _lives.ToString());

            if (_lives < 1)
                GameManager.Instance.GameOver(true);
        }

        _playerGuessWord.text = "";
    }

    private List<string> GetIsogramWords(List<string> wordList) // WordList Class içinden isogram olanları ayıkla
    {
        List<string> isogramWords = new List<string>();

        for (int i = 0; i < wordList.Count; i++)
        {
            if (IsWordIsogram(wordList[i]))
                isogramWords.Add(wordList[i]);
        }

        return isogramWords;
    }

    private bool IsWordIsogram(string word) // Kelimeler isogrammı degil mi tespit et
    {
        int index = 0;
        int comparison = index + 1;

        for (index = 0; index < word.Length; index++)
        {
            for (comparison = index +1; comparison < word.Length; comparison++)
            {
                if (word[index] == word[comparison])
                    return false;
            }
        }

        return true;
    }

    private void GiveHintAboutHiddenWord() // Playera hiddenword hakkında ipucu ver
    {
        int randomLetterIndex = Random.Range(0, _hiddenWord.Length);

        string hint = "The hidden word is " + _hiddenWord.Length + " characters long!\n" +
            "The hidden word has the letter " + _hiddenWord[randomLetterIndex];

        UIManager.Instance.HintUI(hint);
    }
}
