#region StandardUsing
using System;
using System.Text;
using UAManagedCore;
using Store = FTOptix.Store;
#endregion

public class QueryResultLabelLogic : FTOptix.NetLogic.BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }

    [FTOptix.NetLogic.ExportMethod]
    public void RunQuery()
    {

        var project = FTOptix.HMIProject.Project.Current;
        var myStore = project.GetObject("DataStores").Get<Store.Store>("EmbeddedDatabase1");
        object[,] resultSet;
        string[] header;

        var queryLabel = LogicObject.Owner as FTOptix.UI.Label;

        myStore.Query("SELECT COUNT(Column1) FROM Table1", out header, out resultSet);

        if (resultSet.Rank != 2)
            return;

        var rowCount = resultSet != null ? resultSet.GetLength(0) : 0;
        var columnCount = header != null ? header.Length : 0;

        if (rowCount > 0 && columnCount > 0)
        {
            var column1 = Convert.ToInt32(resultSet[0, 0]);
            StringBuilder sb = new StringBuilder("Record Count: ");
            sb.Append(column1);

            var queryResultLabel = LogicObject.Owner as FTOptix.UI.Label;
            queryResultLabel.Text = sb.ToString();

        }
    }
}
