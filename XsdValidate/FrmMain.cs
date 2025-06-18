using System;
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
                    DtdProcessing = DtdProcessing.Prohibit
                };

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

    }
}
