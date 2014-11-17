using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EmailAddressBook_Tomlinson
{
    public partial class ContactInfoForm : Form
    {
        public ContactInfoForm()
        {
            InitializeComponent();
        }
        //field to hold a list of PersonalEntry objects
        private List<PersonalEntry> entryList = new List<PersonalEntry>();

        //Create an instance of the ContactInfoForm class
        //ContactInfoForm myContactInfoForm = new ContactInfoForm();

        private void ContactInfoForm_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile; // to read file
                string line;            // to hold line from file

                //create an instance of the PersonalEntry structure
                PersonalEntry entry = new PersonalEntry();

                //create delim array
                char[] delim = { ',' };

                //open the Contact file
                inputFile = File.OpenText("Contacts.txt");

                //read the Contact file
                while (!inputFile.EndOfStream)
                {
                    //read a line from file
                    line = inputFile.ReadLine();

                    //tokenize line
                    string[] tokens = line.Split(delim);

                    //store the tokens in the entry object
                    entry.name = tokens[0];
                    entry.email = tokens[1];
                    entry.phoneNumber = tokens[2];

                    nameTextBox.Text = entry.name;
                    emailTextBox.Text = entry.email;
                    phoneNumberTextBox.Text = entry.phoneNumber;
                }

            }
            catch (Exception ex)
            {
                //display an error message
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
   }
}