using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace XsdValidate
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {

            edLog.Clear();

            var xsdText = edXsd.Text?.Trim();
            var xmlText = edData.Text?.Trim();

            if (string.IsNullOrEmpty(xsdText) || string.IsNullOrEmpty(xmlText))
            {
                edLog.AppendText("XSD или XML пусты — нечего валидировать.\r\n");
                return;
            }

            try
            {
                 
                var settings = new XmlReaderSettings
                {
                    ValidationType = ValidationType.Schema, 

                };

                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings
                                        | XmlSchemaValidationFlags.ProcessInlineSchema
                                        | XmlSchemaValidationFlags.ProcessSchemaLocation
                                        | XmlSchemaValidationFlags.ProcessIdentityConstraints
                                        | XmlSchemaValidationFlags.AllowXmlAttributes;

                using (var xsdReader = XmlReader.Create(new StringReader(xsdText)))
                {
                    settings.Schemas.Add(null, xsdReader);
                }

                settings.ValidationEventHandler += ValidationHandler;

                using (var xmlReader = XmlReader.Create(new StringReader(xmlText), settings))
                {
                    while (xmlReader.Read()) { /* просто прогоняем поток */ }
                }

                edLog.AppendText("✅ Валидно!\r\n");
            }
            catch (XmlSchemaException ex)
            {
                edLog.AppendText($"❌ Ошибка схемы: {ex.Message}\r\n");
            }
            catch (XmlException ex)
            {
                edLog.AppendText($"❌ Ошибка XML: {ex.Message}\r\n");
            }
            catch (Exception ex)
            {
                edLog.AppendText($"❌ Другая ошибка: {ex.Message}\r\n");
            }

        }

        private void ValidationHandler(object sender, ValidationEventArgs e)
        {
            edLog.AppendText($"❌ {e.Severity}: {e.Message}\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text= "";


            var extractor = new XsdRequiredExtractor();
            extractor.Extract(edXsd.Text, null, textBox1.Text);

            richTextBox1.AppendText("Обязательные элементы:\n");
            foreach (var el in extractor.RequiredElements)
                richTextBox1.AppendText("🧵 - " + el+ "\n");

            richTextBox1.AppendText("Обязательные атрибуты:");
            foreach (var at in extractor.RequiredAttributes)
                richTextBox1.AppendText("👑 - " + at + "\n");
        }
    }
}
