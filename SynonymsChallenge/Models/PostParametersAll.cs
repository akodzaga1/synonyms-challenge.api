namespace SynonymsChallenge.Models
{
    public class PostParametersAll : PostParameters
    {
        public bool getAll { get; set; }
        public string[] retrievedList { get; set; }
        public int skip { get; set; }
    }
}