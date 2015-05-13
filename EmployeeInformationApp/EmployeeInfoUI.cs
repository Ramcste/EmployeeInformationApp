using System;
using System.Collections.Generic;
using System.ComponentModel;
<<<<<<< HEAD
using System.Configuration;
=======
>>>>>>> 5e4be89122815b38b195709b35fa9a6c1509268c
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeInformationApp
{
    public partial class EmployeeInfoUI : Form
    {
        public EmployeeInfoUI()
        {
            InitializeComponent();
<<<<<<< HEAD

            deleteInformationButton.Visible = false;
        }

        string connectionString = ConfigurationManager.ConnectionStrings["EmployeeInformationConString"].ConnectionString;

        private bool isemailexits = false;

        private bool updateMode = false;

        private int employeeId;
=======
        }



>>>>>>> 5e4be89122815b38b195709b35fa9a6c1509268c
        private void saveButton_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            emp.name = nameTextBox.Text;
            emp.address = addressTextBox.Text;
            emp.email = emailTextBox.Text;
            emp.salary = float.Parse(salaryTextBox.Text);

<<<<<<< HEAD
            isemailexits = IsEmailExits(emp.email);

            if (updateMode)
            {
                if (!isemailexits)
                {
                    //  string connectionString = @"Server=.\SQLEXPRESS;Database=Company;Integrated Security=true;";

                    SqlConnection connection = new SqlConnection(connectionString);

                    string query = "UPDATE Employees SET e_name='" + emp.name + "',e_address='" + emp.address +
                                   "',e_email='" + emp.email + "',e_salary='" + emp.salary + "' WHERE e_id='" + employeeId + "' ";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    int rowseffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowseffected > 0)
                    {
                        MessageBox.Show("Data Updated Succssfully");
                        GetDataLoadedInListView();
                    }
                }

                else
                {
                    MessageBox.Show("Updating Email Id already Exists");
                }
=======
           

            if ( IsEmailExits(emp.email))

            {
                MessageBox.Show("This email id already exists");
                return;
>>>>>>> 5e4be89122815b38b195709b35fa9a6c1509268c
            }

            else
            {

<<<<<<< HEAD



                if (isemailexits)
                {
                    MessageBox.Show("This email id already exists");
                }

                else
                {

                    //   string connectionString = @"Server=.\SQLEXPRESS;Database=Company;Integrated Security=true;";

                    SqlConnection connection = new SqlConnection(connectionString);

                    string query = "INSERT INTO Employees VALUES('" + emp.name + "','" + emp.address + "','" + emp.email +
                                   "','" + emp.salary + "')";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    int rowseffected = command.ExecuteNonQuery();
                    connection.Close();

                    if (rowseffected > 0)
                    {
                        MessageBox.Show("Information is saved");
                        GetClearTextBoxes();
                        GetDataLoadedInListView();

                    }
                    else
                    {
                        MessageBox.Show("Error!!");
                    }

                }
=======
                string connectionString = @"Server=ROSHANI;Database=store;Integrated Security=true;";

                SqlConnection connection = new SqlConnection(connectionString);

                string query = "INSERT INTO Employees VALUES('" + emp.name + "','" + emp.address + "','" + emp.email +
                               "','" + emp.salary + "')";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                int rowseffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowseffected > 0)
                {
                    MessageBox.Show("Information is saved");
                    GetClearTextBoxes();
                    GetDataLoadedInListView();

                }
                else
                {
                    MessageBox.Show("Error!!");
                }

>>>>>>> 5e4be89122815b38b195709b35fa9a6c1509268c
            }
        }

        private void GetClearTextBoxes()
        {
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            emailTextBox.Text = "";
            salaryTextBox.Text = "";
        }

        private void EmployeeInfoUI_Load(object sender, EventArgs e)
        {
            GetDataLoadedInListView();

        }

        private bool IsEmailExits(string email)
        {


<<<<<<< HEAD
            //   string connectionString = @"Server=.\SQLEXPRESS;Database=Company;Integrated Security=true;";
=======
            string connectionString = @"Server=ROSHANI;Database=store;Integrated Security=true;";
           
            bool isemailexits = false;

>>>>>>> 5e4be89122815b38b195709b35fa9a6c1509268c

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT e_email FROM Employees WHERE e_email='" + email + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                isemailexits = true;
<<<<<<< HEAD
            }
=======
                break;
            }
            reader.Close();
>>>>>>> 5e4be89122815b38b195709b35fa9a6c1509268c
            connection.Close();

            return isemailexits;

        }



        private void GetDataLoadedInListView()
        {
            employeeListView.Items.Clear();

            List<Employee> employees = new List<Employee>();

<<<<<<< HEAD
            // string connectionString = @"Server=.\SQLEXPRESS;Database=Company;Integrated Security=true;";
=======
            string connectionString = @"Server=ROSHANI;Database=store;Integrated Security=true;";
>>>>>>> 5e4be89122815b38b195709b35fa9a6c1509268c

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Employees";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Employee anEmployee = new Employee();

                anEmployee.id = int.Parse(reader["e_id"].ToString());
                anEmployee.name = reader["e_name"].ToString();
                anEmployee.address = reader["e_address"].ToString();
                anEmployee.email = reader["e_email"].ToString();
                anEmployee.salary = float.Parse(reader["e_salary"].ToString());

                employees.Add(anEmployee);

            }
            connection.Close();

            foreach (var employee in employees)
            {
                ListViewItem item = new ListViewItem();
                item.Text = employee.id.ToString();
                item.SubItems.Add(employee.name);
                item.SubItems.Add(employee.address);
                item.SubItems.Add(employee.email);
                item.SubItems.Add(employee.salary.ToString());
                employeeListView.Items.Add(item);
            }





        }

<<<<<<< HEAD


        private void employeeListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int id = int.Parse(employeeListView.SelectedItems[0].Text);

            employeeId = id;

            //  string connectionString = @"Server=.\SQLEXPRESS;Database=Company;Integrated Security=true;";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT e_name,e_address,e_email,e_salary FROM Employees WHERE e_id='" + id + "'";
=======
       
        private void employeeListView_DoubleClick(object sender, EventArgs e)
        {
            var item = employeeListView.SelectedItems[0];



            int id = int.Parse(item.Text);

            string connectionString = @"Server=ROSHANI;Database=store;Integrated Security=true;";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Employees WHERE e_id='" + id + "'";
>>>>>>> 5e4be89122815b38b195709b35fa9a6c1509268c

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                nameTextBox.Text = reader["e_name"].ToString();
                addressTextBox.Text = reader["e_address"].ToString();
                emailTextBox.Text = reader["e_email"].ToString();
                salaryTextBox.Text = reader["e_salary"].ToString();
<<<<<<< HEAD


            }

            connection.Close();

            updateMode = true;
            saveButton.Text = "Update";
            deleteInformationButton.Visible = true;
        }

        private void deleteInformationButton_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to delete this employee?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                SqlConnection connection = new SqlConnection(connectionString);

                string query = "DELETE  FROM Employees WHERE e_id='" + employeeId + "' ";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                int rowseffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowseffected > 0)
                {
                    MessageBox.Show("Data Deleted Successfully");
                    GetDataLoadedInListView();
                }
            }


        }
=======
                emailTextBox.Enabled = false;

            }
            reader.Close();
            connection.Close();

            saveButton.Text = "Update";
        }
        
>>>>>>> 5e4be89122815b38b195709b35fa9a6c1509268c
    }
}