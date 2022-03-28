using System;
using System.Linq;
using System.Web.Http;
using GroupDocs.Search;

namespace SynonymsChallenge.Models
{
    public class AllSynonymsController : ApiController
    {
        // Bonus controller with paging, show more and show all functionalities

        private string[] mySynonyms = new string[] { };
        // All groups initially represent existing database of synonyms
        string[][] allGroups = new Index().Dictionaries.SynonymDictionary.GetAllSynonymGroups();
        bool hasMore = false;

        // POST api/allsynonyms
        public SynonymsListAll Post([FromBody]PostParametersAll postObject)
        {
            // Search for synonyms in synonyms that are entered in the session + existing database
            // No persistence of data is needed so myCollection is posted on every post
            hasMore = false;
            string word = postObject.word;
            string[][] myCollection = postObject.myCollection;
            bool getAll = postObject.getAll;
            int skip = postObject.skip;
            string[] retrievedList = postObject.retrievedList.Length > 0 ? postObject.retrievedList : new string[] { word };
            // Data is consisted of groups (arrays) of synonyms
            // Word can be found in more than one group
            allGroups = allGroups.Concat(myCollection).ToArray();
            string[] allSynonyms = retrievedList;

            // Resulting array is consisted from already retrieved synonyms + new synonyms
            mySynonyms = retrievedList;

            // Go just through synonyms that are retrieved in previous call and skip elements that are already processed
            for (int i = skip; i < retrievedList.Length; i++)
            {
                allSynonyms = findSynonyms(retrievedList[i], getAll);
            }

            SynonymsListAll retObj = new SynonymsListAll();
            // Return all synonyms except searched word
            retObj.synonyms = allSynonyms.Where(x => x != word).ToArray();
            retObj.hasMore = hasMore;

            return retObj;
        }
        private string[] findSynonyms(string word, bool getAll)
        {
            // Result represents array of words that contains word and none of the words already in resulting array from previous function calls
            // If word is in resulting array it means that all of the words from that group are already processed
            string[][] result = allGroups.Where(x => x.Contains(word) && x.Any(y => !mySynonyms.Contains(y))).Select(x => x).ToArray();
            foreach (string[] s in result)
            {
                // Add words that are not added before to resulting array (next level of synonyms)
                string[] toAdd = s.Where(x => !mySynonyms.Contains(x)).ToArray();
                mySynonyms = mySynonyms.Concat(toAdd).ToArray();
                if (getAll == true)
                {
                    // Part that gets all synonyms of all synonyms (SHOW ALL)
                    foreach (string element in toAdd)
                    {
                        if (element != word)
                            findSynonyms(element, getAll);
                    }
                }
                else if (getAll == false && hasMore == false)
                {
                    // Part that gets no more synonyms, just next level of synonyms that are already in resulting array (SHOW MORE)
                    foreach (string element in toAdd)
                    {
                        // Check if there are synonyms for any newly added word in current level
                        string[][] checkForMore = allGroups.Where(x => x.Contains(element) && x.Any(y => !mySynonyms.Contains(y))).Select(x => x).ToArray();
                        if (checkForMore.Length > 0)
                        {
                            // If there is some more synonyms immediately return resulting array with that information
                            hasMore = true;
                            return mySynonyms;
                        }
                    }
                }
            }
            return mySynonyms;
        }
    }
}
