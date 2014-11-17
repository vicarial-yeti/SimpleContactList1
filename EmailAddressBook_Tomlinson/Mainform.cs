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
    struct PersonalEntry
    {
        public string name;
        public string email;
        public string phoneNumber;
    }

    public partial class Mainform : Form
    {
        //field to hold a list of PersonalEntry objects
        private List<PersonalEntry> entryList = new List<PersonalEntry>();

        public Mainform()
        {
            InitializeComponent();
        }
        //the ReadFile method reads the contents of the Contacts.Txt
        //file and store is as a PersonalEntry object in entryList
        private void ReadFile()
        {
            try
            {
                StreamReader inputFile; // to read file
                string line;            // to hold line from file

                //create an instance of the PersonalEntry structure
                 PersonalEntry entry = new PersonalEntry();
                const int SIZE = 500;
                //create a user array
                int[] users = { SIZE };
                //create delim array
                char[] delim = { ',' };

                //open the Contact file
                inputFile = File.OpenText("Contacts.txt");

                //read the Contact file
                while(!inputFile.EndOfStream)
                {
                    //read a line from file
                    line = inputFile.ReadLine();

                    //tokenize line
                    string[] tokens = line.Split(delim);

                    //store the tokens in the entry object
                    entry.name = tokens[0];
                    entry.email = tokens[1];
                    entry.phoneNumber = tokens[2];

                    //add the entry to the list
                    entryList.Add(entry);
                }

            }
            catch (Exception ex)
            {
                //display an error message
                MessageBox.Show(ex.Message);
            }
        }

        //the DisplayContacts method displays the contacts
        //in the contactsListBox
        private void DisplayContacts()
        {
            foreach (PersonalEntry entry in entryList)
            {
                contactsListBox.Items.Add(entry.name);
                
            }
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            //read the contacts file
            ReadFile();

            //display the names 
            DisplayContacts();
        }

        public void contactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
       
            //get the selected index
            int index = contactsListBox.SelectedIndex;

            //Create an instance of the ContactInfoForm class
            ContactInfoForm myContactInfoForm = new ContactInfoForm();

            //display the users contact info in another form
            myContactInfoForm.ShowDialog();
                       
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
