using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StuMgtSys
{
    public partial class Form1 : Form
    {
        // Connection string for the database
        //private string connectionString = "Data Source=(local);Initial Catalog=StuMgtSysDB;Integrated Security=True";
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StuMgtSysDB;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        // Load student data into the DataGridView
        private void LoadStudentData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command object for calling the stored procedure
                SqlCommand command = new SqlCommand("GetAllStudents", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Create a DataTable to store the student data
                DataTable studentDataTable = new DataTable();

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the command and load the results into the DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(studentDataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = studentDataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Handle the form load event
        private void Form1_Load(object sender, EventArgs e)
        {
            // Load student data into the DataGridView
            LoadStudentData();
        }

        // Handle the button click event to insert a student
        private void btnInsert_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string rollNumber = txtRollNumber.Text;
            string imagePath = txtImagePath.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command object for calling the stored procedure
                SqlCommand command = new SqlCommand("InsertStudent", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the command
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@RollNumber", rollNumber);
                command.Parameters.AddWithValue("@ImagePath", imagePath);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Reload student data into the DataGridView
                    LoadStudentData();

                    // Clear the text boxes
                    txtName.Text = "";
                    txtRollNumber.Text = "";
                    txtImagePath.Text = "";

                    MessageBox.Show("Student inserted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Handle the button click event to update a student
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int studentID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);

            string name = txtName.Text;
            string rollNumber = txtRollNumber.Text;
            string imagePath = txtImagePath.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command object for calling the stored procedure
                SqlCommand command = new SqlCommand("UpdateStudent", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the command
                command.Parameters.AddWithValue("@ID", studentID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@RollNumber", rollNumber);
                command.Parameters.AddWithValue("@ImagePath", imagePath);

                try
                {
                    // Open the```csharp
                    // connection
                    connection.Open();

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Reload student data into the DataGridView
                    LoadStudentData();

                    // Clear the text boxes
                    txtName.Text = "";
                    txtRollNumber.Text = "";
                    txtImagePath.Text = "";

                    MessageBox.Show("Student updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Handle the button click event to delete a student
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int studentID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command object for calling the stored procedure
                SqlCommand command = new SqlCommand("DeleteStudent", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameter to the command
                command.Parameters.AddWithValue("@ID", studentID);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Reload student data into the DataGridView
                    LoadStudentData();

                    // Clear the text boxes
                    txtName.Text = "";
                    txtRollNumber.Text = "";
                    txtImagePath.Text = "";

                    MessageBox.Show("Student deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Handle the DataGridView selection changed event
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                // Fill the text boxes with the selected student's information
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtRollNumber.Text = selectedRow.Cells["RollNumber"].Value.ToString();
                txtImagePath.Text = selectedRow.Cells["ImagePath"].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int studentID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);

            string name = txtName.Text;
            string rollNumber = txtRollNumber.Text;
            string imagePath = txtImagePath.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command object for calling the stored procedure
                SqlCommand command = new SqlCommand("UpdateStudent", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the command
                command.Parameters.AddWithValue("@ID", studentID);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@RollNumber", rollNumber);
                command.Parameters.AddWithValue("@ImagePath", imagePath);

                try
                {
                    // Open the```csharp
                    // connection
                    connection.Open();

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Reload student data into the DataGridView
                    LoadStudentData();

                    // Clear the text boxes
                    txtName.Text = "";
                    txtRollNumber.Text = "";
                    txtImagePath.Text = "";

                    MessageBox.Show("Student updated successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string rollNumber = txtRollNumber.Text;
            string imagePath = txtImagePath.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command object for calling the stored procedure
                SqlCommand command = new SqlCommand("InsertStudent", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters to the command
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@RollNumber", rollNumber);
                command.Parameters.AddWithValue("@ImagePath", imagePath);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Reload student data into the DataGridView
                    LoadStudentData();

                    // Clear the text boxes
                    txtName.Text = "";
                    txtRollNumber.Text = "";
                    txtImagePath.Text = "";

                    MessageBox.Show("Student inserted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            int studentID = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["ID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command object for calling the stored procedure
                SqlCommand command = new SqlCommand("DeleteStudent", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Add parameter to the command
                command.Parameters.AddWithValue("@ID", studentID);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Reload student data into the DataGridView
                    LoadStudentData();

                    // Clear the text boxes
                    txtName.Text = "";
                    txtRollNumber.Text = "";
                    txtImagePath.Text = "";

                    MessageBox.Show("Student deleted successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
