using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace DN9;

public partial class Forms1 : Form
{
    private const string Path = @"C:\Users\HalloKarlRege\Documents\Studium\Semester 7\DNET1\p09\app2020.accdb";
    private const string strConnection = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path;

    public Forms1()
    {
        InitializeComponent();
    }

    private DataView View
    {
        return dataSet1.Tables["Appointments"].DefaultView;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        LoadTable(dataSet1, "Appointments");
        dataGridView1.DataSource = View;
    }

    private void button2_Click(object sender, EventArgs e)
    {
        StoreTable(dataSet1, "Appointments");
    }

    static void LoadTable(DataSet ds, string tableName)
    {
        var con = new OleDbConnection(strConnection);
        var adapter = new OleDbDataAdapter("SELECT * FROM " + tableName, con);
        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        adapter.Fill(ds, tableName);
        if (ds.HasErrors)
        {
            ds.RejectChanges();
            throw new Exception("Error Loading Data");
        }

        ds.AcceptChanges();
        adapter.Dispose();
        Console.WriteLine("Loaded Table:" + tableName);
    }
    
    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        var dateDB = dateTimePicker1.Value.ToString("MM.dd.yyyy");
        View.RowFilter = $"Start > #{dateDB} 00:00:00# and Start < #{dateDB} 23:59:59#";
    }

    static void StoreTable(DataSet ds, string tableName)
    {
        var con = new OleDbConnection(strConnection);
        var adapter = new OleDbDataAdapter("SELECT * FROM " + tableName, con);
        var cmdBuilder = new OleDbCommandBuilder(adapter);
        cmdBuilder.QuotePrefix = "["; cmdBuilder.QuoteSuffix = "]";
        adapter.Update(ds, tableName);
        adapter.Dispose();
        Console.WriteLine("Stored Table:" + tableName);
    }

    
}