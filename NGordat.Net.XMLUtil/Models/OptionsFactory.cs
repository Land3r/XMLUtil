using Fclp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NGordat.Net.XMLUtil.Models
{
    /// <summary>
    /// Options Factory class.
    /// </summary>
    public static class OptionsFactory
    {
        /// <summary>
        /// The command line parser.
        /// </summary>
        public static FluentCommandLineParser<Options> cmdParser = null;

        static OptionsFactory()
        {
            cmdParser = new FluentCommandLineParser<Options>();
            cmdParser.Setup<string>(arg => arg.Input).As('i', "input").Required().WithDescription("The path where to locate the input XML file.");
            cmdParser.Setup<string>(arg => arg.Output).As('o', "output").Required().WithDescription("The path where to write the transformed XML file.");
            cmdParser.Setup<string>(arg => arg.Xslt).As("xslt").Required().WithDescription("The path where to locate the XSLT transformation file that will be applied to the input.");
            cmdParser.Setup<string>(arg => arg.Xsd).As("xsd").WithDescription("(Optional) The path to locate the XSD validation file to assert the structure of the input XML.");
            cmdParser.Setup<bool>(arg => arg.IsVerbose).As('v', "verbose").SetDefault(false).WithDescription("Run in verbose mode.");
            cmdParser.SetupHelp("?", "h", "help").Callback(text => Console.WriteLine(text));
        }

        /// <summary>
        /// Gets the <see cref="Options"/> the program was run with.
        /// </summary>
        /// <param name="args">The args of the program.</param>
        /// <returns>The options the program was run with.</returns>
        public static Options GetOptions(string[] args)
        {
            var result = cmdParser.Parse(args);

            if (result.HasErrors)
            {
                throw new ArgumentException(result.Errors.First().ToString());
            }
            else
            {
                return cmdParser.Object;
            }
        }
    }
}
