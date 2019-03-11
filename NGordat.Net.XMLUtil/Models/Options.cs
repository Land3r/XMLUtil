using System;
using System.Collections.Generic;
using System.Text;
using Fclp;

namespace NGordat.Net.XMLUtil.Models
{
    /// <summary>
    /// Options passed to the program.
    /// </summary>
    public class Options
    {
        /// <summary>
        /// Gets or sets the path of the XML input.
        /// </summary>
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the path of the XML output (after transformation).
        /// </summary>
        public string Output { get; set; }

        /// <summary>
        /// Gets or set the path of the XSLT transformation.
        /// </summary>
        public string Xslt { get; set; }

        /// <summary>
        /// Gets or sets the path of the XSD validation.
        /// </summary>
        public string Xsd { get; set; }

        /// <summary>
        /// Gets or sets whether or not the application is in verbose mode.
        /// </summary>
        public bool IsVerbose { get; set; }
    }
}
