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
        private string[] mySynonyms = new string[] { };
        string[][] allGroups = new string[][] { };

        // POST: api/MySynonyms
        public SynonymsList Post([FromBody]PostParameters postObject)
        {
            string word = postObject.word;
            string[][] myCollection = postObject.myCollection;
            allGroups = myCollection;
            string[] allSynonyms = new string[] { };
            mySynonyms = new string[] { };

            allSynonyms = findSynonyms(word);

            SynonymsList retObj = new SynonymsList();
            retObj.synonyms = allSynonyms.Where(x => x != word).ToArray();

            return retObj;
        }

        private string[] findSynonyms(string word)
        {
            string[][] result = allGroups.Where(x => x.Contains(word) && x.Any(y => !mySynonyms.Contains(y))).Select(x => x).ToArray();
            foreach (string[] s in result)
            {
                string[] toAdd = s.Where(x => !mySynonyms.Contains(x)).ToArray();
                mySynonyms = mySynonyms.Concat(toAdd).ToArray();
                foreach (string element in toAdd)
                {
                    if (element != word)
                        findSynonyms(element);
                }
            }
            return mySynonyms;
        }
    }
}
