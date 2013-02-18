using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using System.Data;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InsertTesti();
            try
            {
                SQLiteDatabase db = new SQLiteDatabase();
                DataTable recipe;
                String query = "select * FROM Unit";
                recipe = db.GetDataTable(query);
                // The results can be directly applied to a DataGridView control
                Console.WriteLine("Data:");
                Console.WriteLine(recipe.PrimaryKey);
                // Or looped through for some other reason
                foreach (DataRow r in recipe.Rows)
                {
                    tBox.Text += (r["UnitName"].ToString()) + "\n";
                }
	
                
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
                this.Close();
            }



            /*
            var connectionString = @"Data Source=C:\Users\ville\Documents\GitHub\InventoryManagementApp\bin\Debug\inventory.s3db; Version=3";
            var connection = new SQLiteConnection(connectionString);
            connection.Open();

            Console.WriteLine(connection.Database);
            Console.WriteLine(connection.LastInsertRowId);

            // Execute query on database
            string insertSQL = "INSERT INTO Unit (UnitName)values(7, 'nakkimakkara')";
            SQLiteCommand insertCommand = new SQLiteCommand(insertSQL, connection);
            insertCommand.ExecuteNonQuery();

            // Execute query on database
            string selectSQL = "SELECT * FROM Unit";
            SQLiteCommand selectCommand = new SQLiteCommand(selectSQL, connection);
            SQLiteDataReader dataReader = selectCommand.ExecuteReader();

            // Iterate every record in the AppUser table
            while (!dataReader.Read())
            {
                tBox.Text+=("User: " + dataReader.GetString(0)
                     + " Username: " + dataReader.GetString(1) + "/n");
            }
            dataReader.Close();
            connection.Close();
            
            /*Material mat = new Material(materialT.Text, Double.Parse(quantityT.Text));
            shoplist.AddToList(mat);

            tBox.Clear();
            List<Material> content = shoplist.Content;
            for (int i = 0; i < content.Count; i++)
            {
                tBox.Text += content[i] + "\n";
            }*/
        }

        void InsertTesti()
        {
            SQLiteDatabase db = new SQLiteDatabase();
            Dictionary<String, String> data = new Dictionary<String, String>();
            data.Add("UnitName", sanoja[col++]);
            try
            {
                db.Insert("Unit", data);
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
            }
        }

        private static int col = 0;
        private static String[] sanoja = {"nakki", "makkara", "keitto", "soppa", "liha"};

        private static ShoppingList shoplist = new ShoppingList();
    }
}
