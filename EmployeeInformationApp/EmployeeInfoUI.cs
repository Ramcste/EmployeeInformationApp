using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }



        private void saveButton_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();

            emp.name = nameTextBox.Text;
            emp.address = addressTextBox.Text;
            emp.email = emailTextBox.Text;
            emp.salary = float.Parse(salaryTextBox.Text);

           

            if ( IsEmailExits(emp.email))

            {
                MessageBox.Show("This email id already exists");
                return;
            }

            else
            {

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


            string connectionString = @"Server=ROSHANI;Database=store;Integrated Security=true;";
           
            bool isemailexits = false;


            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT e_email FROM Employees WHERE e_email='" + email + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                isemailexits = true;
                break;
            }
            reader.Close();
            connection.Close();

            return isemailexits;

        }



        private void GetDataLoadedInListView()
        {
            employeeListView.Items.Clear();

            List<Employee> employees = new List<Employee>();

            string connectionString = @"Server=ROSHANI;Database=store;Integrated Security=true;";

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

       
        private void employeeListView_DoubleClick(object sender, EventArgs e)
        {
            var item = employeeListView.SelectedItems[0];



            int id = int.Parse(item.Text);

            string connectionString = @"Server=ROSHANI;Database=store;Integrated Security=true;";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM Employees WHERE e_id='" + id + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                nameTextBox.Text = reader["e_name"].ToString();
                addressTextBox.Text = reader["e_address"].ToString();
                emailTextBox.Text = reader["e_email"].ToString();
                salaryTextBox.Text = reader["e_salary"].ToString();
                emailTextBox.Enabled = false;

            }
            reader.Close();
            connection.Close();

            saveButton.Text = "Update";
        }
        
    }
}