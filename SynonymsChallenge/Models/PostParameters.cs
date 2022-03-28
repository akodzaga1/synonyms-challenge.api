namespace SynonymsChallenge.Models
{
    public class PostParameters
    {
        public string[][] myCollection { get; set; } // Entered synonyms in current session
        public string word { get; set; } // Word for which we search synonyms
    }
}