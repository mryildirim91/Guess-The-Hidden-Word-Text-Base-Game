using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    [SerializeField]
    private Text _instructionsText, _foundHiddenWordText;
    [SerializeField]
    private Text _livesText, _pointText, _hintText;

    private Queue<string> _gameInstructions;

    [SerializeField]
    private GameObject _gamenInstructionsPanel;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _gameInstructions = new Queue<string>();
        StartGameInstructions();
    }

    private void StartGameInstructions()
    {
        GameInstructions instructions = new GameInstructions();

        _gameInstructions.Clear();

        foreach (string instruction in instructions.Instructions)
        {
            _gameInstructions.Enqueue(instruction);
        }

        DisplayNextInstruction();
    }

    private void DisplayNextInstruction()
    {
        if(_gameInstructions.Count == 0)
        {
            _gamenInstructionsPanel.SetActive(false);
            return;
        }

        string sentence = _gameInstructions.Dequeue();
        StartCoroutine(GameInstructionsRoutine(sentence));
        StopCoroutine(GameInstructionsRoutine(sentence));
    }

    IEnumerator GameInstructionsRoutine(string sentence)
    {
        _instructionsText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            _instructionsText.text += letter;

            yield return null;
        }
    }

    public void FoundTheHiddenWordUI(string text)
    {
        _foundHiddenWordText.text = text;
        _foundHiddenWordText.gameObject.SetActive(true);
 
        StartCoroutine(FoundTheHiddenWordTextRoutine());
        StopCoroutine(FoundTheHiddenWordTextRoutine());
    }

    IEnumerator FoundTheHiddenWordTextRoutine()
    {
        yield return new WaitForSeconds(3);
        _foundHiddenWordText.gameObject.SetActive(false);
    }

    public void LivesUI(string text)
    {
        _livesText.text = text;
    }

    public void PointsUI(string text)
    {
        _pointText.text = text;
    }

    public void HintUI(string text)
    {
        _hintText.text = text;
    }
}


