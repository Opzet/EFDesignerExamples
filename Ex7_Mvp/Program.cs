using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ex7_Mvp.Models;
using Ex7_Mvp.Presenters;
using Ex7_Mvp._Repositories;
using Ex7_Mvp.Views;
using System.Configuration;

namespace Ex7_Mvp
{
    // Adapted from https://github.com/RJCodeAdvance/CRUD-MVP-C-SHARP-SQL-WINFORMS-PART-3-FINAL

    // MVP Design Pattern for winform
    // ------------------------------
    // Workflow
    // <Db Crud [Repository Layer] <-> Model> layer [Interface] (Wires up Model <-> Gui Controls via [Presenter]) based upon events  <Model<-View Events> [GUI] fire Events

    // MODEL: [Datacontext] 
    // PRESENTER: Wire up Model and View together,
    // INTERFACE: events fire CRUD methods in repository
    // VIEW: GUI A passive view

    // MVP changes from Frontend loading Winform RAD to MVP GUI changes via the presenter (Due to databinding not being as good as WPF)
    // i.e dont add gui logis in codebehind methods but reloacte to presenter

    // So No1 rule of Winform coders changing to MVP is DONT DEPEND ON CLASSES, DEPEND ON THE INTERFACES 

    // If you want to have your code testable and maintainable, depend on interface that is implemented by a class.

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Cause Initalise Db to fire, seeds on first instance
            IPetRepository repository = new PetRepository();
            repository = null;

            IMainView view = new MainView();           
            
            new MainPresenter(view);

            Application.Run((Form)view);
        }
    }
}
