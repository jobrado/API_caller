using Commons.Xml.Relaxng;
using System.Xml.Linq;
using System.Xml;
using System;

namespace IIS_Drinks_API.Services
{
    internal class RNGService
    {
        public static bool RNGValidate(string file)
        {
            XmlReader instance = new XmlTextReader(file);
            XmlReader grammar = new XmlTextReader("C:\\Users\\Jo\\Documents\\Svi_predmeti\\6. SESTI SEMESTAR\\IIS\\IIS_Drinks_API\\IIS_Drinks_API\\Assets\\drinks.rng");
            using (RelaxngValidatingReader reader = new RelaxngValidatingReader(instance, grammar))
            {
                try
                {
                    while (!reader.EOF)
                    {
                        reader.Read();
                    }
                    Console.WriteLine("validation succeeded");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("validation failed with message:");
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}