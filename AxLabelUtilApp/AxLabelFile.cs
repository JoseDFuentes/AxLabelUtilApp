using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AxLabelUtilApp
{

    // NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class AxLabelFile
    {

        private string nameField;

        private string labelContentFileNameField;

        private string labelFileIdField;

        private string languageField;

        private string relativeUriInModelStoreField;

        /// <remarks/>
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string LabelContentFileName
        {
            get
            {
                return this.labelContentFileNameField;
            }
            set
            {
                this.labelContentFileNameField = value;
            }
        }

        /// <remarks/>
        public string LabelFileId
        {
            get
            {
                return this.labelFileIdField;
            }
            set
            {
                this.labelFileIdField = value;
            }
        }

        /// <remarks/>
        public string Language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string RelativeUriInModelStore
        {
            get
            {
                return this.relativeUriInModelStoreField;
            }
            set
            {
                this.relativeUriInModelStoreField = value;
            }
        }
    }



}
