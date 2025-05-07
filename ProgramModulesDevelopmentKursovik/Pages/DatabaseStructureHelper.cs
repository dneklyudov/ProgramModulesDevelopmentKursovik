using ProgramModulesDevelopmentKursovik.ApplicationData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProgramModulesDevelopmentKursovik.Pages
{
    internal static class DatabaseStructureHelper
    {
        public static object GetTableTitle(string tableName)
        {
            string json = File.ReadAllText("database.json");
            Root myDeserializedClass = JsonSerializer.Deserialize<Root>(json);

            Console.WriteLine(myDeserializedClass.tRequests.title);

            switch (tableName)
            {
                case "Requests": return myDeserializedClass.tRequests.title;
                case "DoneStates": return myDeserializedClass.tDoneStates.title;
                case "EdIzm": return myDeserializedClass.tEdIzm.title;
                case "Countries": return myDeserializedClass.tCountries.title;
                case "Producers": return myDeserializedClass.tProducers.title;
                case "Suppliers": return myDeserializedClass.tSuppliers.title;
                case "Roles": return myDeserializedClass.tRoles.title;
                case "PaymentStates": return myDeserializedClass.tPaymentStates.title;
                default: throw new ArgumentException("Unknown item type");
            }
        }

        public static List<Field> GetTableFields(string tableName)
        {
            string json = File.ReadAllText("database.json");
            Root myDeserializedClass = JsonSerializer.Deserialize<Root>(json);



            switch (tableName)
            {
                case "Requests": return myDeserializedClass.tRequests.fields;
                case "DoneStates": return myDeserializedClass.tDoneStates.fields;
                case "EdIzm": return myDeserializedClass.tEdIzm.fields;
                case "Countries": return myDeserializedClass.tCountries.fields;
                case "Producers": return myDeserializedClass.tProducers.fields;
                case "Suppliers": return myDeserializedClass.tSuppliers.fields;
                case "Roles": return myDeserializedClass.tRoles.fields;
                case "PaymentStates": return myDeserializedClass.tPaymentStates.fields;
                default: throw new ArgumentException("Unknown item type");
            }
        }
    }


    // https://json2csharp.com/

    public class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool require { get; set; }
        public string title { get; set; }
        public bool visible { get; set; }
        public int? maxlength { get; set; }
        public string itemsource { get; set; }
    }

    public class Root
    {
        public TEdIzm tEdIzm { get; set; }
        public TCountries tCountries { get; set; }
        public TProducers tProducers { get; set; }
        public TSuppliers tSuppliers { get; set; }
        public TRoles tRoles { get; set; }
        public TDoneStates tDoneStates { get; set; }
        public TPaymentStates tPaymentStates { get; set; }
        public TRequests tRequests { get; set; }
    }

    public class TCountries
    {
        public string title { get; set; }
        public List<Field> fields { get; set; }
    }

    public class TDoneStates
    {
        public string title { get; set; }
        public List<Field> fields { get; set; }
    }

    public class TEdIzm
    {
        public string title { get; set; }
        public List<Field> fields { get; set; }
    }

    public class TPaymentStates
    {
        public string title { get; set; }
        public List<Field> fields { get; set; }
    }

    public class TProducers
    {
        public string title { get; set; }
        public List<Field> fields { get; set; }
    }

    public class TRequests
    {
        public string title { get; set; }
        public List<Field> fields { get; set; }
    }

    public class TRoles
    {
        public string title { get; set; }
        public List<Field> fields { get; set; }
    }

    public class TSuppliers
    {
        public string title { get; set; }
        public List<Field> fields { get; set; }
    }
}

