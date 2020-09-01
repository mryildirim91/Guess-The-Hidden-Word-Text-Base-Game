public class GameInstructions
{
    private string[] _instructions =
    {
        "Welcome to the Apples and Pears game!",
        "You have to guess the hidden word which is an isogram which means no repeating letters!",
        "Your guess word must be an isogram and must have the same number of letters as the hidden word!",
        "If you find the hidden word you will get 1 point",
        "You will only have 5 tries until you find the hidden word. Otherwise you will fail!",
        "GOOD LUCK!"
    };

    public string[] Instructions { get { return _instructions; } }
}
