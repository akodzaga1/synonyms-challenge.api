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
        
        //// GET api/allsynonyms
        //public string[] Get()
        //{
        //    return new string[] { "allsynonym1", "allsynonym2" };
        //}

        //// GET api/allsynonyms/{word}
        //public string[] Get(string word)
        //{
        //    string[] allSynonyms = new string[] { };
        //    mySynonyms = new string[] { };
        //    //wantedWord = word;
        //    allSynonyms = findSynonyms(word);

        //    return allSynonyms.Where(x => x != word).ToArray();
        //}

        private string[] findSynonyms(string word)
        {
            string[][] result = allGroups.Where(x => x.Contains(word) && x.Any(y => !mySynonyms.Contains(y))).Select(x => x).ToArray();
            foreach (string[] s in result)
            {
                string[] toAdd = s.Where(x => !mySynonyms.Contains(x)).ToArray();
                mySynonyms = mySynonyms.Concat(toAdd).ToArray();
                foreach(string element in s)
                {
                    if(element != word)
                        findSynonyms(element);
                }
            }
            return mySynonyms;
        }
        // POST api/allsynonyms
        public string[] Post([FromBody]PostParameters postObject)
        {
            string word = postObject.word;
            string[][] myCollection = postObject.myCollection;
            allGroups = allGroups.Concat(myCollection).ToArray();
            string[] allSynonyms = new string[] { };
            mySynonyms = new string[] { };
            
            allSynonyms = findSynonyms(word);

            return allSynonyms.Where(x => x != word).ToArray();
        }

        //// PUT api/allsynonyms/5
        //public void Put(int id, [FromBody]string allsynonym)
        //{
        //}

        //// DELETE api/allsynonyms/5
        //public void Delete(int id)
        //{
        //}
    }
}
