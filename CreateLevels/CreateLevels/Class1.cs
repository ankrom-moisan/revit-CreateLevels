using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;




namespace CreateLevels
{

    [Transaction(TransactionMode.Manual)]

    class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;


            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("MyTransaction");
                Level level = doc.Create.NewLevel(0);
                if (null == level)

                    level.Name = "New Name";
                ElementId nid = level.Id;

                tx.Commit();
            }
            throw new Exception("Create new level failed.");
            //throw new NotImplementedException();
        }
    }
}
