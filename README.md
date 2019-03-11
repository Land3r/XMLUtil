# XMLUtil
A small cmdline utility to run XSD validation / XSLT transformation

# Build
Build using .NET Core (2.2+)

# Usage
Run using dotnet cmdline :
```
dotnet NGordat.Net.XMLUtil.dll -i "Path_to_XML" -o "Path_to_transformed_XML" -xslt "Path_to_XSLT"
```

```
Usage :
  i:input         The path where to locate the input XML file.
  o:output        The path where to write the transformed XML file.
  v:verbose       (Optional) Run in verbose mode.
  xslt            The path where to locate the XSLT transformation file that will be applied to the input.
  xsd             (Optional) The path to locate the XSD validation file to assert the structure of the input XML.
```

# Help
```
dotnet NGordat.Net.XMLUtil.dll -?
```
