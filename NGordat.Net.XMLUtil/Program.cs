using NGordat.Net.XMLUtil.Models;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace NGordat.Net.XMLUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            Options options = null;
            try
            {
                // Get the args.
                options = OptionsFactory.GetOptions(args);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occured.");
                Console.WriteLine("Usage :");
                OptionsFactory.cmdParser.HelpOption.ShowHelp(OptionsFactory.cmdParser.Options);
                throw;
            }

            // Read input file.
            Console.WriteLine("Reading file {0}", options.Input);
            XDocument input = XDocument.Load(options.Input);
            if (options.IsVerbose)
            {
                Console.Write(input.ToString());
            }

            // Validate input file if requested
            if (options.Xsd != null)
            {
                Console.WriteLine("Validating file with {0}", options.Xsd);
                XDocument xsd = XDocument.Load(options.Xsd);
                if (options.IsVerbose)
                {
                    Console.Write(xsd.ToString());
                }
                XmlSchemaSet xsdSchemas = new XmlSchemaSet();
                bool hasErrors = false;
                xsdSchemas.Add(string.Empty, XmlReader.Create(new StringReader(xsd.ToString())));
                input.Validate(xsdSchemas, (o, e) => { Console.WriteLine("Errors validating XML : {0}", e.Message); hasErrors = true; });

                if (hasErrors)
                {
                    Console.WriteLine("Exiting");
                    Environment.Exit(0);
                }
            }
            
            Console.WriteLine("Transforming file with {0}", options.Xslt);
            XDocument xslt = XDocument.Load(options.Xslt);
            if (options.IsVerbose)
            {
                Console.Write(xslt.ToString());
            }
            XDocument output = new XDocument();
            using (XmlWriter writer = output.CreateWriter())
            {
                // Load the style sheet.  
                XslCompiledTransform xsltCompiled = new XslCompiledTransform();
                xsltCompiled.Load(XmlReader.Create(new StringReader(xslt.ToString())));

                // Execute the transform and output the results to a writer.  
                xsltCompiled.Transform(output.CreateReader(), writer);
            }

            Console.WriteLine("Output of the transformation to {0}", options.Output);
            Console.Write(output.ToString());
            if (options.IsVerbose)
            {
                output.Save(options.Output);
            }
            Console.WriteLine("Exiting");
        }
    }
}
