using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAccountingSystem
{
    internal class Register
    {
        public Register() 
        {
            _documents = new List<Document>();
        }

        public void SaveDoc(Document doc) 
        { 
            if( _documents.Count > 10 )
            {
                Console.WriteLine("Количество документов в регистре не может быть больше 10.");
            }
            else
            {
                _documents.Add( doc );
                Console.WriteLine($"Информация о документе {doc.DocNumber} сохранена.");
            }
        }

        public void GetDocInfo(Document doc)
        {
            if (_documents.Contains(doc))
            {
                doc.GetDocInfo();
            }
            else
            {
                Console.WriteLine($"Информация о документе {doc.DocNumber} отсутствует.");
            }
        }

        private List<Document> _documents;
    }
}
