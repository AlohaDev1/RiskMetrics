using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportSicCodes
{
    class Program
    {
        /// took sic code from
        /// https://github.com/saintsjd/sic4-list
        /// 
        static void Main(string[] args)
        {
            //ForJsTreeParse();

            ForClassCode();
        }

        private static void ForClassCode()
        {
            var output = new StringBuilder();

            var lines = File.ReadAllLines("2012_NAICS_Structure.csv").Skip(1).ToList();

            lines = lines.Where(t => !string.IsNullOrEmpty(t.Split(';')[1])).ToList();

            var fixedLins = new List<string>();
            //fix for T on ending
            foreach (var line in lines)
            {
                //var lValues = line.Split(';');
                var newLine = line;
                if (line.EndsWith("T ;;;"))
                {
                    newLine = line.Substring(0, (line.Length - "T ;;;".Length));
                }

                if (line.EndsWith("T;;;"))
                {
                    newLine = line.Substring(0, (line.Length - "T;;;".Length));
                }
                
                fixedLins.Add(newLine);
            }


            var code2 = fixedLins.Where(t => t.Split(';')[1].Length == 2);
            var code3 = fixedLins.Where(t => t.Split(';')[1].Length == 3);
            var code4 = fixedLins.Where(t => t.Split(';')[1].Length == 4);
            var code5 = fixedLins.Where(t => t.Split(';')[1].Length == 5);
            var code6 = fixedLins.Where(t => t.Split(';')[1].Length == 6);

            var csStrs = new List<string>();
            foreach (var c2 in code2)
            {
                var c2Values = c2.Split(';');
                var childrens2String = "";
                var cs3Strs = new List<string>();
                
                
                foreach (var cs3 in code3.Where(t=> t.Split(';')[1].StartsWith(c2Values[1])))
                {
                    var c3Values = cs3.Split(';');
                    var childrens3String = "";
                    var cs4Strs = new List<string>();

                    foreach (var c4 in code4.Where(t=>t.Split(';')[1].StartsWith(c3Values[1])))
                    {
                        var c4Values = c4.Split(';');
                        var children4String = "";
                        var cs5Strs = new List<string>();

                        foreach (var c5 in code5.Where(t=>t.Split(';')[1].StartsWith(c4Values[1])))
                        {
                            var c5Values = c5.Split(';');
                            var children5String = "";
                            var cs6Strs = new List<string>();
                            foreach (var cs6Str in cs6Strs.Where(t=>t.Split(';')[1].StartsWith(c5Values[1])))
                            {
                                var c6Values = cs6Str.Split(',');
                                cs6Strs.Add(string.Format("{{ data: \"{0} {1}\", attr: {{ class: 'classCode', 'data-classCode': \"{0}\" }} }}", c6Values[1], c6Values[2]));
                            }

                            children5String = string.Join(",", cs6Strs);
                            cs5Strs.Add(string.Format("{{ data: \"{0} {2}\", attr: {{ class: 'classCode', 'data-classCode': \"{0}\" }}, children: [{1}] }}", c5Values[1], children5String, c5Values[2]));
                        }
                        children4String = string.Join(",", cs5Strs);
                        cs4Strs.Add(string.Format("{{ data: \"{0} {2}\", attr: {{ class: 'classCode', 'data-classCode': \"{0}\" }}, children: [{1}]}}", c4Values[1], children4String, c4Values[2]));
                    }

                    childrens3String = string.Join(",", cs4Strs);
                    cs3Strs.Add(string.Format("{{ data: \"{0} {2}\", attr: {{ class: 'classCode', 'data-classCode': \"{0}\" }}, children: [{1}]}}", c3Values[1], childrens3String, c3Values[2]));

                }

                childrens2String = string.Join(",", cs3Strs);
                csStrs.Add(string.Format("{{ data: \"{0} {2}\", attr: {{ class: 'classCode', 'data-classCode': \"{0}\" }}, children: [{1}] }}", c2Values[1], childrens2String, c2Values[2]));
            }
            

            File.WriteAllText("OutputClassCode.txt", string.Format("gClassCodes = \n[{0}]", string.Join(",", csStrs)));
        }

        public static void ForJsTreeParse()
        {
            var output = new StringBuilder();

            var devisionsGroups = File.ReadAllLines("sic4-list-master/divisions.csv").Skip(1).ToList();
            var majorGroups = File.ReadAllLines("sic4-list-master/major-groups.csv").Skip(1).ToList();
            var industryGroups = File.ReadAllLines("sic4-list-master/industry-groups.csv").Skip(1).ToList();
            var sicCodesList = File.ReadAllLines("sic4-list-master/sic-codes.csv").Skip(1).ToList();

            var firstDevision = true;
            foreach (var devisionsGroup in devisionsGroups)
            {
                //var str = ParseCsvRow(devisionsGroup);
                var devValues = ParseCsvRow(devisionsGroup);
                var devCode = devValues[0];

                output.AppendFormat("{2}\n{{ \n\t id: '{0}',\n\t data: '{0} {1}',\n\t children: [", devValues[0], devValues[1].Replace("\"", string.Empty), firstDevision ? "" : ",");

                var firstMajorGroup = true;
                foreach (var majorGroup in majorGroups.Where(m => m.StartsWith(devCode)))
                {
                    //var majorGroupValues = majorGroup.Split(',');
                    var majorGroupValues = ParseCsvRow(majorGroup);
                    var majorCode = majorGroupValues[1];
                    var majorString = new StringBuilder();
                    majorString.AppendFormat("{2}\n{{\n\t id:'00{0}',\n\t data:\"{0} {1}\",\n\t", majorCode, majorGroupValues[2].Replace("\"", string.Empty), firstMajorGroup ? "" : ",");

                    var industryItems = industryGroups.Where(i => i.Split(',')[1].Equals(majorCode));
                    var industryString = new StringBuilder();
                    var industryFirst = true;
                    foreach (var industryItem in industryItems)
                    {
                        var industryItemValue = ParseCsvRow(industryItem);
                        var industryCode = industryItemValue[2];
                        industryString.AppendFormat("{2}\n\t\t{{\n\t\t\t id:'0{0}',\n\t\t\t data:\"{0} {1}\",\n\t\t\t", industryCode, industryItemValue[3].Replace("\"", string.Empty), industryFirst ? "" : ",");

                        var sicCodes = sicCodesList.Where(s => s.Split(',')[2].Equals(industryCode));
                        var sicString = new StringBuilder();
                        var sicFirst = true;
                        foreach (var sicCode in sicCodes)
                        {
                            var sicCodeValue = ParseCsvRow(sicCode);
                            sicString.AppendFormat("{2}\n\t\t\t\t{{ attr: {{ 'data-sicCode': '{0}', 'class': 'cb-sicCode' }}, data: \"{0} {1} \"}}", sicCodeValue[3], sicCodeValue[4].Replace("\"", string.Empty), sicFirst ? "" : ",");
                            sicFirst = false;
                        }

                        industryString.AppendFormat(" children: [{0}\n\t\t\t] \n\t\t}}", sicString);
                        industryFirst = false;
                    }

                    majorString.AppendFormat(" children: [{0}\n\t] \n}}", industryString);

                    output.Append(majorString);
                    firstMajorGroup = false;
                }

                output.Append("]}");

                firstDevision = false;
            }



            File.WriteAllText("Output.txt", string.Format("gSicCodes = \n[{0}]", output));

            Console.WriteLine("Import done");
            Console.WriteLine("Major count:{0}", majorGroups.Count());
            Console.WriteLine("Industry count:{0}", industryGroups.Count());
            Console.WriteLine("SicCode count:{0}", sicCodesList.Count());

            Console.ReadLine();
        }

        public static void ForKendoParse()
        {
            var output = new StringBuilder();

            var devisionsGroups = File.ReadAllLines("sic4-list-master/divisions.csv").Skip(1).ToList();
            var majorGroups = File.ReadAllLines("sic4-list-master/major-groups.csv").Skip(1).ToList();
            var industryGroups = File.ReadAllLines("sic4-list-master/industry-groups.csv").Skip(1).ToList();
            var sicCodesList = File.ReadAllLines("sic4-list-master/sic-codes.csv").Skip(1).ToList();

            var firstDevision = true;
            foreach (var devisionsGroup in devisionsGroups)
            {
                //var str = ParseCsvRow(devisionsGroup);
                var devValues = ParseCsvRow(devisionsGroup);
                var devCode = devValues[0];

                output.AppendFormat("{2}\n{{ \n\t id: '{0}',\n\t text: '{0} {1}',\n\t items: [", devValues[0], devValues[1].Replace("\"", string.Empty), firstDevision ? "" : ",");

                var firstMajorGroup = true;
                foreach (var majorGroup in majorGroups.Where(m => m.StartsWith(devCode)))
                {
                    //var majorGroupValues = majorGroup.Split(',');
                    var majorGroupValues = ParseCsvRow(majorGroup);
                    var majorCode = majorGroupValues[1];
                    var majorString = new StringBuilder();
                    majorString.AppendFormat("{2}\n{{\n\t id:'00{0}',\n\t text:\"{0} {1}\",\n\t", majorCode, majorGroupValues[2].Replace("\"", string.Empty), firstMajorGroup ? "" : ",");

                    var industryItems = industryGroups.Where(i => i.Split(',')[1].Equals(majorCode));
                    var industryString = new StringBuilder();
                    var industryFirst = true;
                    foreach (var industryItem in industryItems)
                    {
                        var industryItemValue = ParseCsvRow(industryItem);
                        var industryCode = industryItemValue[2];
                        industryString.AppendFormat("{2}\n\t\t{{\n\t\t\t id:'0{0}',\n\t\t\t text:\"{0} {1}\",\n\t\t\t", industryCode, industryItemValue[3].Replace("\"", string.Empty), industryFirst ? "" : ",");

                        var sicCodes = sicCodesList.Where(s => s.Split(',')[2].Equals(industryCode));
                        var sicString = new StringBuilder();
                        var sicFirst = true;
                        foreach (var sicCode in sicCodes)
                        {
                            var sicCodeValue = ParseCsvRow(sicCode);
                            sicString.AppendFormat("{2}\n\t\t\t\t{{ id:'{0}', text: \"{0} {1} \"}}", sicCodeValue[3], sicCodeValue[4].Replace("\"", string.Empty), sicFirst ? "" : ",");
                            sicFirst = false;
                        }

                        industryString.AppendFormat(" items: [{0}\n\t\t\t] \n\t\t}}", sicString);
                        industryFirst = false;
                    }

                    majorString.AppendFormat(" items: [{0}\n\t] \n}}", industryString);

                    output.Append(majorString);
                    firstMajorGroup = false;
                }

                output.Append("]}");

                firstDevision = false;
            }



            File.WriteAllText("Output.txt", string.Format("gSicCodes = \n[{0}]", output));

            Console.WriteLine("Import done");
            Console.WriteLine("Major count:{0}", majorGroups.Count());
            Console.WriteLine("Industry count:{0}", industryGroups.Count());
            Console.WriteLine("SicCode count:{0}", sicCodesList.Count());

            Console.ReadLine();
        }

        public static string[] ParseCsvRow(string r)
        {

            string[] c;
            string t;
            List<string> resp = new List<string>();
            bool cont = false;
            string cs = "";

            c = r.Split(new char[] { ',' }, StringSplitOptions.None);

            foreach (string y in c)
            {
                string x = y;


                if (cont)
                {
                    // End of field
                    if (x.EndsWith("\""))
                    {
                        cs += "," + x.Substring(0, x.Length - 1);
                        resp.Add(cs);
                        cs = "";
                        cont = false;
                        continue;

                    }
                    else
                    {
                        // Field still not ended
                        cs += "," + x;
                        continue;
                    }
                }

                // Fully encapsulated with no comma within
                if (x.StartsWith("\"") && x.EndsWith("\""))
                {
                    if ((x.EndsWith("\"\"") && !x.EndsWith("\"\"\"")) && x != "\"\"")
                    {
                        cont = true;
                        cs = x;
                        continue;
                    }

                    resp.Add(x.Substring(1, x.Length - 2));
                    continue;
                }

                // Start of encapsulation but comma has split it into at least next field
                if (x.StartsWith("\"") && !x.EndsWith("\""))
                {
                    cont = true;
                    cs += x.Substring(1);
                    continue;
                }

                // Non encapsulated complete field
                resp.Add(x);

            }

            return resp.ToArray();

        }


    }
}

//{
//        id: '0001',
//        text: "01 AGRICULTURAL PRODUCTION CROPS",
//        items: [
//            {
//                id: '0011',
//                text: "011 CASH GRAINS",
//                items: [
//                    { id: '0111', text: "0111 WHEAT" },
//                    { id: '0112', text: "0112 RICE" },
//                    { id: '0115', text: "0115 CORN" },
//                    { id: '0116', text: "0116 SOYBEANS" },
//                    { id: '0119', text: "0119 CASH GRAINS, NOT ELSEWHERE CLASSIFIED" }
//                ]
//            },
//            {
//                id: '0013',
//                text: "013 FIELD CROPS, EXCEPT CASH GRAINS",
//                items: [
//                    { id: '0131', text: "0131 COTTON" },
//                    { id: '0132', text: "0132 TOBACCO" },
//                    { id: '0133', text: "0133 SUGARCANE AND SUGAR BEETS" },
//                    { id: '0134', text: "0134 IRISH POTATOES" },
//                    { id: '0139', text: "0139 FIELD CROPS, EXCEPT CASH GRAINS, NOT ELSEWHERE CLASSIFIED" }
//                ]
//            }
//        ]
//    }