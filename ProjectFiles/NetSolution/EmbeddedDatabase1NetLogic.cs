#region Using directives
using System;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.Store;

#endregion

public class EmbeddedDatabase1NetLogic : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [ExportMethod]
public void InsertRandomValues (){

    // Get the current project folder.
    var project = Project.Current;

    // Save the names of the columns of the table to an array
    string[] columns = { "Column1", "Column2", "Column3" };

    // Create and populate a matrix with values to insert into the odbc table
    var rawValues = new object[1000, 3];

    Random randomNumber = new Random ();

    for (UInt16 i = 0; i < 1000; ++i)
    {
        // Column1
        rawValues[i, 0] = i;

        // Column2
        rawValues[i, 1] = randomNumber.Next(0, 5000);

        // Column3
        rawValues[i, 2] = randomNumber.NextDouble() * 5000;
    }
    var myStore = LogicObject.Owner as Store;

    // Get Table1 from myStore
    var table1 = myStore.Tables.Get<Table>("Table1");

    // Insert values into table1
    table1.Insert(columns, rawValues);
}
}
