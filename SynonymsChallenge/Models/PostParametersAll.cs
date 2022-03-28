namespace SynonymsChallenge.Models
{
    public class PostParametersAll : PostParameters
    {
        public bool getAll { get; set; } // If true get all synonyms of all synonyms for given word
        public string[] retrievedList { get; set; } // List of words already retrieved by client
        public int skip { get; set; } // Optimization for paging, skip elements that are already processed
    }
}