using System;
using System.Linq;
using System.Web.Http;
using GroupDocs.Search;

namespace SynonymsChallenge.Models
{
    public class AllSynonymsController : ApiController
    {
        private string[] mySynonyms = new string[] { };
        string[][] allGroups = new Index().Dictionaries.SynonymDictionary.GetAllSynonymGroups();
        bool hasMore = false;

        // POST api/allsynonyms
        public SynonymsListAll Post([FromBody]PostParametersAll postObject)
        {
            hasMore = false;
            string word = postObject.word;
            string[][] myCollection = postObject.myCollection;
            bool getAll = postObject.getAll;
            int skip = postObject.skip;
            string[] retrievedList = postObject.retrievedList.Length > 0 ? postObject.retrievedList : new string[] { word };
            allGroups = allGroups.Concat(myCollection).ToArray();
            string[] allSynonyms = retrievedList;
            mySynonyms = retrievedList;

            for (int i = skip; i < retrievedList.Length; i++)
            {
                allSynonyms = findSynonyms(retrievedList[i], getAll);
            }

            SynonymsListAll retObj = new SynonymsListAll();
            retObj.synonyms = allSynonyms.Where(x => x != word).ToArray();
            retObj.hasMore = hasMore;

            return retObj;
        }

        private string[] findSynonyms(string word, bool getAll)
        {
            string[][] result = allGroups.Where(x => x.Contains(word) && x.Any(y => !mySynonyms.Contains(y))).Select(x => x).ToArray();
            foreach (string[] s in result)
            {
                string[] toAdd = s.Where(x => !mySynonyms.Contains(x)).ToArray();
                mySynonyms = mySynonyms.Concat(toAdd).ToArray();
                if (getAll == true)
                {
                    foreach (string element in toAdd)
                    {
                        if (element != word)
                            findSynonyms(element, getAll);
                    }
                }
                else if (getAll == false && hasMore == false)
                {
                    foreach (string element in toAdd)
                    {
                        string[][] checkForMore = allGroups.Where(x => x.Contains(element) && x.Any(y => !mySynonyms.Contains(y))).Select(x => x).ToArray();
                        if (checkForMore.Length > 0)
                            hasMore = true;
                    }

                }

            }
            return mySynonyms;
        }
    }
}
