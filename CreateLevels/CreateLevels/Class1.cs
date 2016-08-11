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
        //private object document;

        public Result Execute(
            ExternalCommandData commandData,
            ref string message,
            ElementSet elements)

        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            {

                Level level = doc.Create.NewLevel(0);
                if (null == level)
                {
                    throw new Exception("Create new level failed.");
                }
                level.Name = "New Name";
                ElementId nid = level.Id;

                return level;

            }

        }

    }

}





    

        


       
        


            













    //    {
    //        UIApplication uiapp = commandData.Application;
    //        UIDocument uidoc = uiapp.ActiveUIDocument;
    //        Application app = uiapp.Application;
    //        Document doc = uidoc.Document;

//        using (Transaction trans = new Transaction(doc, "Level"))
//        {

//            trans.Start();


//            {
//                double elevation = 20.0;

//                Level level = doc.Create.NewLevel(elevation);
//                if (null == level)
//                {
//                    throw new Exception("Create a new level failed.");
//                }
//                // change the leve name
//                level.Name = "New Level";

//                return Result.Succeeded;

//                trans.Commit();
//            }
//        }

//    }
//}




