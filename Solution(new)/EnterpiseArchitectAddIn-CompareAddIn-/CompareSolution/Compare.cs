using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EA;

namespace Solution
{
    enum CompareResult
    {
        Identically, Changed, Removed, Added
    }
    class Compare
    {
        List<Element> l, r;
        string type;
        List<Element> identical = new List<Element>();
        List<Element> newest = new List<Element>();
        List<Tuple<Element, Element>> modifyed = new List<Tuple<Element, Element>>();
        List<Element> deleted = new List<Element>();
        List<Dictionary<string, object>> stats = new List<Dictionary<string, object>>();

        
        private List<string> requirementStats = new List<string>() { "Name", "Status", "Difficulty", "Priority", "Stereotype" };
        private List<string> useCaseStats = new List<string>() { "Name", "Status", "Difficulty", "Priority", "Stereotype" };
        private List<string> classStats = new List<string>() { "Name", "Status", "Difficulty", "Priority", "Stereotype" };

        public List<List<string>> allStats = new List<List<string>>();
  
        public Compare(List<Element> l, List<Element> r)
        {
            this.l = l;
            this.r = r;

            allStats.Add(requirementStats);
            allStats.Add(useCaseStats);
            allStats.Add(classStats);

            findDeleted();
            findNewest();
            findModifyedAndIdentical();   
        }

        private void findNewest() {
            HashSet<string> names = new HashSet<string>();
            foreach (Element el in l) {
                names.Add(el.Name);
            }
            foreach (Element el in r)
            {
                if (!names.Contains(el.Name)) {
                    newest.Add(el);
                }
            }
        }

        private void findDeleted()
        {
            HashSet<string> names = new HashSet<string>();
            foreach (Element el in r)
            {
                names.Add(el.Name);
            }
            foreach (Element el in l)
            {
                if (!names.Contains(el.Name))
                {
                    deleted.Add(el);
                }
            }
        }

        private Dictionary<string, object> compareAttributes(Element l, Element r)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["Name"] = CompareResult.Identically;
            dict["Status"] = l.Status != r.Status ? CompareResult.Changed : CompareResult.Identically;
            dict["Alias"] = l.Alias != r.Alias ? CompareResult.Changed : CompareResult.Identically;
            dict["Author"] = l.Author != r.Author ? CompareResult.Changed : CompareResult.Identically;
            dict["Difficulty"] = l.Difficulty != r.Difficulty ? CompareResult.Changed : CompareResult.Identically;
            dict["Priority"] = l.Priority != r.Priority ? CompareResult.Changed : CompareResult.Identically;
            dict["Version"] = l.Version != r.Version ? CompareResult.Changed : CompareResult.Identically;
            dict["Stereotype"] = l.Stereotype != r.Stereotype ? CompareResult.Changed : CompareResult.Identically;


            //Collection leftReqs = l.Requirements;
            //Collection rightReqs = r.Requirements;

            //int leftReqCnt = leftReqs.Count;
            //int rightReqCnt = rightReqs.Count;

            //foreach (Requirement lreq in leftReqs)
            //{
            //    foreach (Requirement rreq in rightReqs)
            //    {
                     
            //    }
            //}
            return dict;
        }

        private void findModifyedAndIdentical()
        {
            List<Tuple<Element, Element>> forCompare = new List<Tuple<Element,Element>>();
            Dictionary<string, Element> names = new Dictionary<string, Element>();
            foreach (Element el in l)
            {
                names.Add(el.Name, el);
            }
            foreach (Element el in r)
            {
                if (names.ContainsKey(el.Name))
                {
                    forCompare.Add(new Tuple<Element, Element>(names[el.Name], el));
                }
            }
            foreach (Tuple<Element, Element> t in forCompare)
            {
                stats.Add(compareAttributes(t.Item1, t.Item2));
                modifyed.Add(t);
            }
        }

        public List<Tuple<Element, Element>> getModifyed()
        {
            return modifyed;
        }
        public List<Element> getNewest()
        {
            return newest;
        }
        public List<Element> getDeleted()
        {
            return deleted;
        }
        public List<Element> getEquals()
        {
            return identical;
        }

        public List<Dictionary<string, object>> getStats()
        {
            return stats;
        }




    }
}
