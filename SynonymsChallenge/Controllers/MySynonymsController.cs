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

        //// GET: api/MySynonyms
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/MySynonyms/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        private string[] findSynonyms(string word)
        {
            string[][] result = allGroups.Where(x => x.Contains(word) && x.Any(y => !mySynonyms.Contains(y))).Select(x => x).ToArray();
            foreach (string[] s in result)
            {
                string[] toAdd = s.Where(x => !mySynonyms.Contains(x)).ToArray();
                mySynonyms = mySynonyms.Concat(toAdd).ToArray();
                foreach (string element in s)
                {
                    if (element != word)
                        findSynonyms(element);
                }
            }
            return mySynonyms;
        }

        // POST: api/MySynonyms
        public string[] Post([FromBody]PostParameters postObject)
        {
            string word = postObject.word;
            string[][] myCollection = postObject.myCollection;
            allGroups = myCollection;
            string[] allSynonyms = new string[] { };
            mySynonyms = new string[] { };

            allSynonyms = findSynonyms(word);

            return allSynonyms.Where(x => x != word).ToArray();
        }

        //// PUT: api/MySynonyms/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/MySynonyms/5
        //public void Delete(int id)
        //{
        //}
    }
}
