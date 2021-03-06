﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PABPProjekat1.src.DB
{
    public class Suppliers
    {
        public List<Supplier> SupplierList { get; set; }

        public Supplier GetSupplier(string companyName)
        {
            Supplier s = null;

            NorthwindDataSet nwds = new NorthwindDataSet();
            NorthwindDataSetTableAdapters.SuppliersTableAdapter suppliersTableAdapter = new NorthwindDataSetTableAdapters.SuppliersTableAdapter();

            suppliersTableAdapter.Fill(nwds.Suppliers);

            DataRow[] dataRows = nwds.Suppliers.Select("CompanyName = '" + companyName + "'");

            
            if(dataRows.Length == 1)
            {
                s = new Supplier();
                s.Load(dataRows[0]);
            }
            else if(dataRows.Length > 1)
            {
                // Aleksa: datarow more than one result is not alowed at the moment
                throw new NotImplementedException("More than one result in DB is not alowed at the moment!");
            }
            else
            {
                throw new Exception("No record found for CompanyName = '" + companyName + "'");
            }

            return s;
        }
    }

    public class Supplier
    {
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        // Aleksa: not a table column
        public string Password { get; set; }

        public void Load(DataRow row)
        {
            SupplierID = row.Field<int>("SupplierID");
            CompanyName = row.Field<string>("CompanyName");
            ContactName = row.Field<string>("ContactName");
            ContactTitle = row.Field<string>("ContactTitle");
            Address = row.Field<string>("Address");
            City = row.Field<string>("City");
            Region = row.Field<string>("Region");
            PostalCode = row.Field<string>("PostalCode");
            Country = row.Field<string>("Country");
            Phone = row.Field<string>("Phone");
            Fax = row.Field<string>("Fax");
            HomePage = row.Field<string>("HomePage");

            // Aleksa: escaping the special characters from number and postal code
            Password = ParsePassword(Phone, PostalCode);
        }

        private string ParsePassword(params string[] stringsToParse)
        {
            string value = String.Empty;

            for (int i = 0; i < stringsToParse.Count(); i++)
            {
                stringsToParse[i] = stringsToParse[i].Replace("(", string.Empty);
                stringsToParse[i] = stringsToParse[i].Replace(")", string.Empty);
                stringsToParse[i] = stringsToParse[i].Replace(" ", string.Empty);
                stringsToParse[i] = stringsToParse[i].Replace("-", string.Empty);

                value += stringsToParse[i];
            }

            return value;
        }
    }

}
