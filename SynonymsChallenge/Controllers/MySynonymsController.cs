using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SynonymsChallenge.Models
{
    public class MySynonymsController : ApiController
    {
        // Main controller based on task requirements

        private string[] mySynonyms = new string[] { };
        string[][] allGroups = new string[][] { };

        // POST: api/MySynonyms
        public SynonymsList Post([FromBody]PostParameters postObject)
        {
            // Search for synonyms in synonyms that are entered in the session
            // No persistence of data is needed so myCollection is posted on every post
            string word = postObject.word;
            string[][] myCollection = postObject.myCollection;
            // Data is consisted of groups (arrays) of synonyms
            // Word can be found in more than one group
            allGroups = myCollection;
            string[] allSynonyms = new string[] { };
            mySynonyms = new string[] { };

            allSynonyms = findSynonyms(word);

            SynonymsList retObj = new SynonymsList();
            // Return all synonyms except searched word
            retObj.synonyms = allSynonyms.Where(x => x != word).ToArray();

            return retObj;
        }
        private string[] findSynonyms(string word)
        {
            // Recursive function that follows transition and equivalency rules
            // a -> b -> c => a -> c
            // a -> b => b -> a

            // Result represents array of words that contains word and none of the words already in resulting array from previous function calls
            // If word is in resulting array it means that all of the words from that group are already processed
            string[][] result = allGroups.Where(x => x.Contains(word) && x.Any(y => !mySynonyms.Contains(y))).Select(x => x).ToArray();

            foreach (string[] s in result)
            {
                // Adding words that are not added before to resulting array
                string[] toAdd = s.Where(x => !mySynonyms.Contains(x)).ToArray();
                mySynonyms = mySynonyms.Concat(toAdd).ToArray();
                foreach (string element in toAdd)
                {
                    // For every new element call function findSynonyms recursively
                    if (element != word)
                        findSynonyms(element);
                }
            }
            return mySynonyms;
        }
    }
}
