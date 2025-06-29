using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Schema;

namespace XsdValidate
{

    public class XsdRequiredExtractor
    {
        private readonly XmlSchemaSet schemaSet = new XmlSchemaSet();
        private readonly List<string> elements = new List<string>();
        private readonly List<string> attributes = new List<string>();
        string rep;
        public void Extract(string xsd, string targetNamespace = null, string resp="")
        {
            rep = resp;
            schemaSet.ValidationEventHandler += (s, e) => throw e.Exception;

            var xsdReader = XmlReader.Create(new StringReader(xsd));
                        
            schemaSet.Add(targetNamespace, xsdReader);
            schemaSet.Compile();

            foreach (XmlSchema schema in schemaSet.Schemas())
                foreach (XmlSchemaElement root in schema.Elements.Values)
                    TraverseElement(root, root.ElementSchemaType,  root.QualifiedName.ToString());
        }

        public IReadOnlyList<string> RequiredElements => elements;
        public IReadOnlyList<string> RequiredAttributes => attributes;

        private void TraverseElement(XmlSchemaElement elem, XmlSchemaType type, string path)
        {
            var pathaa = "";
            if (string.IsNullOrEmpty(rep))
                pathaa = path;
            else
                pathaa = path.Replace(rep, "");

            if (elem.MinOccurs >= 1)
                elements.Add(pathaa);

            if (type is XmlSchemaComplexType ct)
            {
                foreach (XmlSchemaAttribute att in ct.AttributeUses.Values)
                    if (att.Use == XmlSchemaUse.Required)
                    {
                       
                        attributes.Add($"{pathaa}@{att.Name}");
                    }

                TraverseParticle(ct.ContentTypeParticle, path);
            }
        }

        private void TraverseParticle(XmlSchemaParticle particle, string path)
        {
            if (particle == null) return;

            switch (particle)
            {
                case XmlSchemaGroupRef grpRef:
                    var grp = schemaSet.Schemas()
                        .Cast<XmlSchema>()
                        .SelectMany(s => s.Groups.Values.Cast<XmlSchemaGroup>())
                        .FirstOrDefault(g => g.QualifiedName == grpRef.RefName);
                    if (grp?.Particle != null)
                        TraverseParticle(grp.Particle, path);
                    break;

                case XmlSchemaSequence seq:
                    foreach (XmlSchemaObject item in seq.Items)
                        ProcessItem(item, path);
                    break;

                case XmlSchemaChoice choice:
                    foreach (XmlSchemaObject item in choice.Items)
                        ProcessItem(item, path);
                    break;

                case XmlSchemaAll all:
                    foreach (XmlSchemaObject item in all.Items)
                        ProcessItem(item, path);
                    break;
            }
        }

        private void ProcessItem(XmlSchemaObject item, string path)
        {
            switch (item)
            {
                case XmlSchemaElement child:
                    TraverseElement(child, child.ElementSchemaType, $"{path}/{child.QualifiedName}");
                    break;

                case XmlSchemaParticle p:
                    TraverseParticle(p, path);
                    break;
            }
        }
    }
}
