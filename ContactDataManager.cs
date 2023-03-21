﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem_LINQ
{
    public class ContactDataManager
    {
        // UC01------->Create DataTable
        DataTable dataTable;

        public void CreateDataTable()
        {
            dataTable = new DataTable();
            DataColumn dtColumn = new DataColumn();

            // Create FirstName Column
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "FirstName";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create LastName Column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "LastName";
            dtColumn.Caption = "Last Name";
            dtColumn.AutoIncrement = false;

            dataTable.Columns.Add(dtColumn);

            // Create Address Column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Address";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create City Column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "City";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create State Column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "State";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create EmailId Column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(String);
            dtColumn.ColumnName = "Email";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create Address column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "PhoneNumber";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

            // Create ZipCode Column
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Int64);
            dtColumn.ColumnName = "Zip";
            dtColumn.Caption = "Zip";
            dtColumn.AutoIncrement = false;
            dataTable.Columns.Add(dtColumn);

        }
        //UC02------->Insert values in Data Table
        public int AddValues()
        {
            CreateDataTable();
            //Create Object for DataTable
            Contact contact1 = new Contact();
            Contact contact2 = new Contact();

            // Insert Values of contact1 into Table
            contact1.firstName = "Nick";
            contact1.lastName = "Rao";
            contact1.phoneNumber = 1234567890;
            contact1.emailId = "Nick@gmail.com";
            contact1.address = "4,B Block,SP Nagar";
            contact1.city = "Vizag";
            contact1.state = "AP";
            contact1.zipCode = 600132;
            InsertintoDataTable(contact1);

            // Insert Values of contact2 into Table
            contact2.firstName = "Sam";
            contact2.lastName = "R";
            contact2.phoneNumber = 9888812349;
            contact2.emailId = "Sam2@gmail.com";
            contact2.address = "Ranapuram";
            contact2.city = "Pune";
            contact2.state = "MH";
            contact2.zipCode = 123001;
            InsertintoDataTable(contact2);
            return dataTable.Rows.Count;
        }

        //Insert values in Data Table
        public void InsertintoDataTable(Contact contact)
        {
            DataRow dtRow = dataTable.NewRow();
            dtRow["FirstName"] = contact.firstName;
            dtRow["LastName"] = contact.lastName;
            dtRow["Address"] = contact.address;
            dtRow["City"] = contact.city;
            dtRow["State"] = contact.state;
            dtRow["Zip"] = contact.zipCode;
            dtRow["PhoneNumber"] = contact.phoneNumber;
            dtRow["Email"] = contact.emailId;
            dataTable.Rows.Add(dtRow);

        }
        //UC03------->Ability to edit existing contact person using their name
        public bool ModifyDataTableUsingName(string FirstName, string ColumnName, string value)
        {
            AddValues();
            var modifiedList = (from Contact in dataTable.AsEnumerable() where Contact.Field<string>("FirstName") == FirstName select Contact).LastOrDefault();
            if (modifiedList != null)
            {
                modifiedList[ColumnName] = value;
                Display();
                return true;
            }
            return false;
        }
        //UC-04---->Ability to delete a person using person'sname
        public bool DeleteRecordUsingName(string FirstName)
        {            
            AddValues();        
            var modifiedList = (from Contact in dataTable.AsEnumerable() where Contact.Field<string>("FirstName") == FirstName select Contact).FirstOrDefault();
            if (modifiedList != null)
            {
                modifiedList.Delete();
                Console.WriteLine("******* After Deletion ******");
                Display();
                return true;
            }
            return false;
        }
        //Display all Values in DataRow
        public void Display()
        {

            Console.WriteLine("\n-------------Values in datatable------------\n");
            foreach (DataRow dtRows in dataTable.Rows)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}\n", dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
            }
        }
    }
}
