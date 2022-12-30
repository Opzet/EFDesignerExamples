 ## MVP Design Pattern for winform 
 
 > Paradigm change for C# Winform Code behind developers:
 
 > Rule #1: Depend on the INTERFACE that is implemented by a class - Do not front end load Winform (CodeBehind)
 
### Workflow = Link up Interfaces using Presenter
IRepository <= Presenter => IView

i.e <Db Crud [Repository Layer] <-> Model> layer [Interface] (Wires up Model <-> Gui Controls via [Presenter]) based upon events  <Model<-View Events> [GUI] fire Events

## MVP SUMMARY:
> REPOSITORY: Db WORKER -> Db CRUD & Methods
### MODEL: [Datacontext] 
>INTERFACE: Exposes worker events 
### VIEW: GUI A databound view
>INTERFACE: Properties expose databinding to UI
### PRESENTER: GUI WORKER -> Logic Wires up Repository and View together via Interfaces , uses events to fire GUI Update / reads 

## NOTES:
MVP changes from Frontend loading Winform RAD to MVP GUI changes via the presenter (Due to databinding not being as good as WPF)
i.e dont add gui logis in codebehind methods but reloacte to presenter

So #1 rule of Winform programer changing to MVP is <DON'T DEPEND ON CLASSES> , [DEPEND ON THE <INTERFACES>!]

If you want to have your code testable and maintainable, depend on interface that is implemented by a class.

## MVP Dev Process

## REPOSITORY:
a. Using <EF Visual Editor> manually define data layout/structure then -> Auto Generate MODEL (this feeds the next steps)
Database Db
 <TableA -> FieldA>
Auto Generate class: Model.generated.cs
 We are after
 <Model.FieldA>
 
b. Create: ModelRepository.cs Code up Ef Db context CRUD operations (Create/Read/Update/Delete) methods and filter / select data methods
          
c. Create: IModelRepository.cs -> Manually Expose <b> interface via
  Interface IRepository.cs is like header.h file in c
  
```             
public interface IRepository
{
 void Add(Model model);
 IEnumerable<PetModel> GetAll();
}   
```

## VIEWS:
a. Using <Winform RAD> layout Appearance, generates form.designer.cs
b. Add codebehind to expose forms control fields {get;set;} into form.cs
```
public string Model
{
  get { return txtName.Text; }
  set { txtName.Text = value; }
}
```
           
c. Create Interface IView 
```
public interface IView
{
 public event EventHandler eViewEvent;
}   
```
## PRESENTER: 
a.
